using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.CommonComponents
{
    public class ReloadLevelComponent : MonoBehaviour
    {
        public void Reload()
        {
            var currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.name);
        }
    }
}