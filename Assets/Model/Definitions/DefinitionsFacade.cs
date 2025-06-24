using UnityEngine;

namespace Assets.Model.Definitions
{
    [CreateAssetMenu(menuName = "Definitions/DefinitionsFacade", fileName = "DefinitionsFacade")]
    public class DefinitionsFacade : ScriptableObject
    {
        [SerializeField]
        private InventoryItemsDefinitions _inventoryItemDefinitions;

        private static DefinitionsFacade _instance;

        public InventoryItemsDefinitions InventoryItemDefinitions
            => _inventoryItemDefinitions;

        public static DefinitionsFacade Instance
            => _instance == null ? LoadDefinitions() : _instance;

        private static DefinitionsFacade LoadDefinitions()
            => _instance = Resources.Load<DefinitionsFacade>("DefinitionsFacade");

        public ItemDefinition Get(string id)
            => _inventoryItemDefinitions.Get(id);
    }
}
