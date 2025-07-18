using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.PixelCrew.UI.LevelsLoader
{
    public class LevelLoader : MonoBehaviour
    {
        private static readonly int Enabled = Animator.StringToHash("Enabled");

        [SerializeField]
        private Animator _animator;

        [SerializeField]
        private float _transitionTime;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        private static void OnAfterSceneLoad()
        {
            InitializeLoader();
        }

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

        private static void InitializeLoader()
        {
            SceneManager.LoadScene("LevelLoader", LoadSceneMode.Additive);
        }

        public void LoadLevel(string sceneName)
        {
            StartCoroutine(StartAnimation(sceneName));
        }

        private IEnumerator StartAnimation(string sceneName)
        {
            _animator.SetBool(Enabled, true);
            yield return new WaitForSeconds(_transitionTime);
            SceneManager.LoadScene(sceneName);
            _animator.SetBool(Enabled, false);
        }
    }
}
