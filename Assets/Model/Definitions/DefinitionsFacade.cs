using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Model.Definitions
{
    [CreateAssetMenu(menuName = "Definitions/DefinitionsFacade", fileName = "DefinitionsFacade")]
    public class DefinitionsFacade : ScriptableObject
    {
        [SerializeField]
        private InventoryItemDefinitions inventoryItemDefinitions;

        private static DefinitionsFacade _instance;

        public static DefinitionsFacade Instance
            => _instance ? LoadDefinitions() : _instance;

        private static DefinitionsFacade LoadDefinitions()
            => _instance = Resources.Load<DefinitionsFacade>("DefinitionsFacade");
    }
}
