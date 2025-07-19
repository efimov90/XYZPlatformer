using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Utils
{
    public class CheatController : MonoBehaviour
    {
        private string _currentInput;

        [SerializeField] private float _inputTimeToLive;
        [SerializeField] private Cheat[] _cheats;

        private float _inputTime;

        private void Awake()
        {
            Keyboard.current.onTextInput += OnTextInput;
        }

        private void Update()
        {
            if (_inputTime > 0)
            {
                _inputTime -= Time.deltaTime;
            }
            else
            {
                _currentInput = "";
            }
        }

        private void OnDestroy()
        {
            Keyboard.current.onTextInput -= OnTextInput;
        }

        private void OnTextInput(char inputSymbol)
        {
            _currentInput += inputSymbol;
            _inputTime = _inputTimeToLive;
            FindAndExecuteCheatIfExists();
        }

        private void FindAndExecuteCheatIfExists()
        {
            foreach (var cheat in _cheats)
            {
                if (_currentInput.Contains(cheat.CheatCode))
                {
                    cheat.Action?.Invoke();
                    _currentInput = "";

                    return;
                }
            }
        }
    }
}