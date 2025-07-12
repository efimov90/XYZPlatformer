using UnityEngine;
using UnityEngine.UI;

namespace Assets.PixelCrew.UI.Widgets
{
    public class CustomButton : Button
    {
#if UNITY_EDITOR
        /// <summary>
        /// Название поля для редактора Unity, где хранится текст для состояния "Normal".
        /// </summary>
        public const string NormalStateFieldName = nameof(_normal);

        /// <summary>
        /// Название поля для редактора Unity, где хранится текст для состояния "Pressed".
        /// </summary>
        public const string PressedStateFieldName = nameof(_pressed);
#endif

        [SerializeField]
        private GameObject _normal;

        [SerializeField]
        private GameObject _pressed;

        protected override void DoStateTransition(SelectionState state, bool instant)
        {
            base.DoStateTransition(state, instant);

            _normal.SetActive(state != SelectionState.Pressed);
            _pressed.SetActive(state == SelectionState.Pressed);
        }
    }
}