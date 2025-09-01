using Cinemachine;
using System.Collections;
using UnityEngine;

namespace Assets.PixelCrew.CommonComponents.Effects.CameraRelated
{
    [RequireComponent(typeof(CinemachineVirtualCamera))]
    public class CameraShakeEffect : MonoBehaviour
    {
        private CinemachineBasicMultiChannelPerlin _noise;
        private Coroutine _coroutine;

        [SerializeField]
        private float _animationTime = 0.3f;

        [SerializeField]
        private float _intensity = 3f;

        private void Awake()
        {
            var virtualCamera = GetComponent<CinemachineVirtualCamera>();
            _noise = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        }

        public void Shake()
        {
            if(_coroutine != null)
            {
                StopAnimation();
            }

            _coroutine = StartCoroutine(StartAnimation());
        }

        private IEnumerator StartAnimation()
        {
            _noise.m_FrequencyGain = _intensity;
            yield return new WaitForSeconds(_animationTime);
            StopAnimation();
        }

        private void StopAnimation()
        {
            _noise.m_FrequencyGain = 0;
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
    }
}
