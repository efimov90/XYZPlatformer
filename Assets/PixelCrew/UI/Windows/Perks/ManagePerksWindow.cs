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

        private PredefinedDataGroup<string, PerkWidget> _perksGroup;

        private readonly CompositeDisposable _trash = new CompositeDisposable();

        protected override void Start()
        {
            base.Start();

            _perksGroup = new PredefinedDataGroup<string, PerkWidget>(_perksContainer);


        }
    }
}
