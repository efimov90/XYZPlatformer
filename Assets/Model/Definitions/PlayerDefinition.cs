using UnityEngine;

namespace Assets.Model.Definitions
{
    [CreateAssetMenu(menuName = "Definitions/PlayerDefinition", fileName = "PlayerDefinition")]
    public class PlayerDefinition : ScriptableObject
    {
        [SerializeField]
        private int _inventorySize;

        [SerializeField]
        private int _maxHealth;

        public int InventorySize => _inventorySize;

        public int MaxHealth => _maxHealth;
    }
}
