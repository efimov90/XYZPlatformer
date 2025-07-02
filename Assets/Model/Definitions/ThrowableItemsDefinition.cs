using System.Linq;
using UnityEngine;

namespace Assets.Model.Definitions
{
    [CreateAssetMenu(menuName = "Definitions/ThrowableItems", fileName = "ThrowableItems")]
    public class ThrowableItemsDefinition : ScriptableObject
    {
        [SerializeField]
        private ThrowableItemDefinition[] _items;

        public ThrowableItemDefinition Get(string id)
            => _items.FirstOrDefault(item => item.Id == id);
    }
}
