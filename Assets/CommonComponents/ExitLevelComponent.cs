using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.CommonComponents
{
    public class ExitLevelComponent : MonoBehaviour
    {
        [SerializeField]
        private string _sceneName;

        public void Exit()
        {
            Debug.Log($"Exit triggered");
            SceneManager.LoadScene(_sceneName);
        }
    }
}
