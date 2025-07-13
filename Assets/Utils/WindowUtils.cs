using UnityEngine;

namespace Assets.Utils
{
    public class WindowUtils
    {
        public static void CreateWindow(string path)
        {
            var window = Resources.Load<GameObject>(path);
            var canvas = Object.FindObjectOfType<Canvas>();
            Object.Instantiate(window, canvas.transform);
        }
    }
}
