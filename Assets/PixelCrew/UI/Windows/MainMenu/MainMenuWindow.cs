using Assets.PixelCrew.UI.LevelsLoader;
using System;
using UnityEngine;

namespace Assets.PixelCrew.UI.Windows.MainMenu
{
    public class MainMenuWindow : AnimatedWindow
    {
        private Action _closeAction;
        public void OnStartGame()
        {
            _closeAction = StartGame;

            Close();
        }

        public void OnShowSettings()
        {
            var window = Resources.Load<GameObject>("UI/SettingsWindow");
            var canvas = FindObjectOfType<Canvas>();

            Instantiate(window, canvas.transform);
        }

        public void OnShowLanguage()
        {
            var window = Resources.Load<GameObject>("UI/LocalizationMenuWindow");
            var canvas = FindObjectOfType<Canvas>();

            Instantiate(window, canvas.transform);
        }

        public void OnExit()
        {
            _closeAction = QuitGame;

            Close();
        }

        private void StartGame()
        {
            var loader = FindObjectOfType<LevelLoader>();
            loader.LoadLevel("Level1");
        }

        private void QuitGame()
        {
            Application.Quit();

#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }

        public override void OnCloseAnimationComplete()
        {
            base.OnCloseAnimationComplete();

            _closeAction?.Invoke();
        }
    }
}
