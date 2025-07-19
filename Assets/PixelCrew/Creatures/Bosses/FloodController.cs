using System.Collections;
using UnityEngine;

namespace Assets.PixelCrew.Creatures.Bosses
{
    public class FloodController : MonoBehaviour
    {
        private static readonly int Flood = Animator.StringToHash("IsFlooding");
        private Coroutine _corutine;

        [SerializeField]
        private Animator _floodAnimator;

        [SerializeField]
        private float _floodTime;

        public void StartFlooding()
        {
            if (_corutine != null)
            {
                return;
            }

            _corutine = StartCoroutine(Animate());
        }

        private IEnumerator Animate()
        {
            _floodAnimator.SetBool(Flood, true);

            yield return new WaitForSeconds(_floodTime);

            _floodAnimator.SetBool(Flood, false);

            _corutine = null;
        }
    }
}
