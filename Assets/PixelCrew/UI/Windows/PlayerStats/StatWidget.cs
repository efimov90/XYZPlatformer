using Assets.Model.Definitions.Player;
using Assets.PixelCrew.UI.Widgets;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.PixelCrew.UI.Windows.PlayerStats
{
    public class StatWidget : MonoBehaviour, IItemRenderer<StatDefinition>
    {
        [SerializeField]
        private Image _icon;

        [SerializeField]
        private Text _name;

        [SerializeField]
        private Text _currentValue;

        [SerializeField]
        private Text _increaseValue;

        [SerializeField]
        private ProgressBarWidget _progress;

        [SerializeField]
        private GameObject _selector; 

        public void SetData(StatDefinition data, int index)
        {
            
        }
    }
}
