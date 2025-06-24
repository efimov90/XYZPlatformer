using Assets.Model;
using Assets.Model.Definitions;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.CommonComponents.Interactions
{
    public class RequiredtemComponent : MonoBehaviour
    {
        [InventoryId]
        [SerializeField]
        private string _id;

        [SerializeField]
        private int _count;

        [SerializeField]
        private bool _removeAfterUse;

        [SerializeField]
        private UnityEvent _onSuccess;

        [SerializeField]
        private UnityEvent _onFailure;

        public void Check()
        {
            var session = FindObjectOfType<GameSession>();

            var count = session.PlayerData.Inventory.GetCountOf(_id);

            if (count >= _count)
            {
                if (_removeAfterUse)
                {
                    session.PlayerData.Inventory.Remove(_id, _count);
                }

                _onSuccess?.Invoke();
            }
            else
            {
                _onFailure?.Invoke();
            }
        }
    }
}
