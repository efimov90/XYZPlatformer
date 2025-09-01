using Assets.Model;
using Assets.Model.Definitions;
using Assets.Model.Definitions.Localization;
using Assets.Model.Definitions.Repositories;
using Assets.PixelCrew.UI.Widgets;
using Assets.Utils.Disposables;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.PixelCrew.UI.Windows.Perks
{
    public class ManagePerksWindow : AnimatedWindow
    {
        [SerializeField]
        private Button _buyButton;

        [SerializeField]
        private Button _useButton;

        [SerializeField]
        private ItemWidget _price;

        [SerializeField]
        private Text _information;

        [SerializeField]
        private Transform _perksContainer;

        private PredefinedDataGroup<PerkDefinition, PerkWidget> _perksGroup;

        private readonly CompositeDisposable _trash = new CompositeDisposable();

        private GameSession _gameSession;

        protected override void Start()
        {
            base.Start();

            _perksGroup = new PredefinedDataGroup<PerkDefinition, PerkWidget>(_perksContainer);
            _gameSession = FindObjectOfType<GameSession>();

            _trash.Retain(_gameSession.PerksModel.Subscribe(OnPerksChanged));
            _trash.Retain(_buyButton.onClick.Subscribe(OnBuy));
            _trash.Retain(_useButton.onClick.Subscribe(OnUse));

            OnPerksChanged();
        }

        private void OnPerksChanged()
        {
            _perksGroup.SetData(DefinitionsFacade.Instance.PerkRepository.All);

            var selectedPerkId = _gameSession.PerksModel.InterfaceSelection.Value;

            _useButton.gameObject.SetActive(_gameSession.PerksModel.IsUnlocked(selectedPerkId));
            _useButton.interactable = _gameSession.PerksModel.Used != selectedPerkId;

            _buyButton.gameObject.SetActive(!_gameSession.PerksModel.IsUnlocked(selectedPerkId));
            _buyButton.interactable = _gameSession.PerksModel.CanBuy(selectedPerkId);

            var definition = DefinitionsFacade.Instance.PerkRepository.Get(selectedPerkId);
            _price.SetData(definition.Price);

            _information.text = LocalizationManager.Instance.Localize(definition.Information);
        }

        private void OnBuy()
        {
            var perkId = _gameSession.PerksModel.InterfaceSelection.Value;
            _gameSession.PerksModel.Unlock(perkId);
        }

        private void OnUse()
        {
            var perkId = _gameSession.PerksModel.InterfaceSelection.Value;
            _gameSession.PerksModel.Use(perkId);
        }

        private void OnDestroy()
        {
            _trash.Dispose();
        }
    }
}
