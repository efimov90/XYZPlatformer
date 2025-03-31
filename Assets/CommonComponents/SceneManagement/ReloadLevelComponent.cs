using Assets.PixelCrew.Model;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.CommonComponents.SceneManagement
{
    public class ReloadLevelComponent : MonoBehaviour
    {
        public void Reload()
        {
            var session = FindObjectOfType<GameSession>();
            DestroyImmediate(session);
            var currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.name);
        }
    }
}