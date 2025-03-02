using Assets.PixelCrew.Creatures;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.PixelCrew
{
    public class HeroInputReader : MonoBehaviour
    {
        [SerializeField]
        private Hero _hero;
        private HeroInputActions _inputActions;

        private void Awake()
        {
            _inputActions = new HeroInputActions();
        }

        private void OnEnable()
        {
            _inputActions.Hero.AxisMovement.performed += OnAxisMovement;
            _inputActions.Hero.AxisMovement.canceled += OnAxisMovement;
            _inputActions.Hero.Interact.performed += OnInteractPerformed;
            _inputActions.Hero.Attack.performed += OnAttackPerformed;
            _inputActions.Enable();
        }

        private void OnInteractPerformed(InputAction.CallbackContext context)
        {
            _hero.Interact();
        }

        public void OnAttackPerformed(InputAction.CallbackContext context)
        {
            if (context.canceled)
            {
                _hero.Attack();
            }
        }

        private void OnAxisMovement(InputAction.CallbackContext callbackContext)
        {
            var direction = callbackContext.ReadValue<Vector2>();
            _hero.SetDirection(direction);
        }

        private void OnDisable()
        {
            _inputActions.Hero.AxisMovement.performed -= OnAxisMovement;
            _inputActions.Hero.AxisMovement.canceled -= OnAxisMovement;
            _inputActions.Hero.Interact.performed -= OnInteractPerformed;
            _inputActions.Hero.Attack.performed -= OnAttackPerformed;
            _inputActions.Disable();
        }
    }
}