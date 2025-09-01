using UnityEngine;

namespace Assets.Utils
{
    public class WindowUtils
    {
        public static void CreateWindow(string path)
        {
            var window = Resources.Load<GameObject>(path);
            var canvas = GameObject.FindWithTag("MainUICanvas").GetComponent<Canvas>();
            Object.Instantiate(window, canvas.transform);
        }
    }
}
