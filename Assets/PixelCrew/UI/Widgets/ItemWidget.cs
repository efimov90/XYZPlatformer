using Assets.Model.Definitions;
using Assets.Model.Definitions.Repositories;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.PixelCrew.UI.Widgets
{
    public class ItemWidget : MonoBehaviour
    {
        [SerializeField]
        private Image _icon;

        [SerializeField]
        private Text _value;

        public void SetData(ItemWithCount definition)
        {
            var itemDefinition = DefinitionsFacade.Instance.Get(definition.Id);

            _icon.sprite = itemDefinition.Icon;
            _value.text = $"{definition.Count}";
        }
    }
}
