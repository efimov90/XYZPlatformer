using UnityEngine;

namespace Assets.Model.Definitions.Player
{
    [CreateAssetMenu(menuName = "Definitions/PlayerDefinition", fileName = "PlayerDefinition")]
    public class PlayerDefinition : ScriptableObject
    {
        [SerializeField]
        private int _inventorySize;

        [SerializeField]
        private int _maxHealth;

        [SerializeField]
        private StatDefinition[] _stats;

        public int InventorySize => _inventorySize;

        public int MaxHealth => _maxHealth;

        public StatDefinition[] Stats => _stats;

        public StatDefinition GetStat(StatId id)
        {
            foreach (var item in _stats)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }

            return default;
        }
    }
}
