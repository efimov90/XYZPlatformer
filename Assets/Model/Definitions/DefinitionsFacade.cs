using UnityEngine;

namespace Assets.Model.Definitions
{
    [CreateAssetMenu(menuName = "Definitions/DefinitionsFacade", fileName = "DefinitionsFacade")]
    public class DefinitionsFacade : ScriptableObject
    {
        [SerializeField]
        private InventoryItemsDefinitions _inventoryItemDefinitions;

        [SerializeField]
        private PlayerDefinition _playerDefinition;

        [SerializeField]
        private ThrowableItemsDefinition _throwableItemsDefinition;

        private static DefinitionsFacade _instance;

        public InventoryItemsDefinitions InventoryItemDefinitions
            => _inventoryItemDefinitions;

        public ThrowableItemsDefinition ThrowableItemsDefinition
            => _throwableItemsDefinition;

        public PlayerDefinition PlayerDefinition
            => _playerDefinition;

        public static DefinitionsFacade Instance
            => _instance == null ? LoadDefinitions() : _instance;

        private static DefinitionsFacade LoadDefinitions()
            => _instance = Resources.Load<DefinitionsFacade>("DefinitionsFacade");

        public ItemDefinition Get(string id)
            => _inventoryItemDefinitions.Get(id);
    }
}
