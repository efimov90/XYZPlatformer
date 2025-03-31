using Assets.CommonComponents.Sword;
using UnityEngine;

namespace Assets.CommonComponents.Collectables
{
    public class ModifySwordCountComponent : MonoBehaviour
    {
        [SerializeField] private int _swordDelta;

        public void Modify(GameObject target)
        {
            if (!(target.GetComponent<SwordBagComponent>() is SwordBagComponent swordBagComponent))
            {
                return;
            }

            if (_swordDelta > 0)
            {
                swordBagComponent.Give(_swordDelta);
            }
            else
            {
                swordBagComponent.Withdraw(-_swordDelta);
            }
        }
    }
}
