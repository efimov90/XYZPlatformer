using Assets.CommonComponents.Collectables;
using UnityEngine;

namespace Assets.CommonComponents
{
    public class JumpBoostComponent : MonoBehaviour
    {
        [SerializeField] private float _jumpBoostAmount;

        public void Modify(GameObject target)
        {
            if (target.GetComponent<BuffComponent>() is BuffComponent buffComponent)
            {
                buffComponent.JumpBoost(_jumpBoostAmount);
            }
        }
    }
}
