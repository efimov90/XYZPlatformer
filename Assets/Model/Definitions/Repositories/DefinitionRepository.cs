using System.Linq;
using UnityEngine;

namespace Assets.Model.Definitions.Repositories
{
    public class DefinitionRepository<TDefinitionType>
        : ScriptableObject
        where TDefinitionType : IHaveId
    {
        [SerializeField]
        protected TDefinitionType[] _collection;

        public TDefinitionType Get(string id)
        {
            if(string.IsNullOrWhiteSpace(id))
            {
                return default;
            }

            return _collection.FirstOrDefault(x => x.Id == id);
        }

        public TDefinitionType[] All => _collection.ToArray();
    }
}
