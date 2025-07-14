using Assets.Model.Definitions.Player;
using Assets.Model.Definitions.Repositories;
using UnityEngine;

namespace Assets.Model.Definitions
{
    [CreateAssetMenu(menuName = "Definitions/DefinitionsFacade", fileName = "DefinitionsFacade")]
    public class DefinitionsFacade : ScriptableObject
    {
        private static DefinitionsFacade _instance;

        [SerializeField]
        private InventoryItemsDefinitions _inventoryItemDefinitions;

        [SerializeField]
        private PlayerDefinition _playerDefinition;

        [SerializeField]
        private ThrowableItemsDefinition _throwableItemsDefinition;

        [SerializeField]
        private PerkRepository _perkRepository;

        public InventoryItemsDefinitions InventoryItemDefinitions
            => _inventoryItemDefinitions;

        public ThrowableItemsDefinition ThrowableItemsDefinition
            => _throwableItemsDefinition;

        public PerkRepository PerkRepository => _perkRepository;

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
