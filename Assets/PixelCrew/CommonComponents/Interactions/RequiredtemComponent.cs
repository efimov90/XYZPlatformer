using Assets.Model;
using Assets.Model.Data;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.PixelCrew.CommonComponents.Interactions
{
    public class RequiredtemComponent : MonoBehaviour
    {
        [SerializeField]
        private InventoryItemData[] _required;

        [SerializeField]
        private bool _removeAfterUse;

        [SerializeField]
        private UnityEvent _onSuccess;

        [SerializeField]
        private UnityEvent _onFailure;

        public void Check()
        {
            var session = FindObjectOfType<GameSession>();

            var inventory = session.PlayerData.Inventory;

            if (inventory.Contains(_required))
            {
                if (_removeAfterUse)
                {
                    session.PlayerData.Inventory.Remove(_required);
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
