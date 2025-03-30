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
            _inputActions.Enable();
        }

        private void OnInteractPerformed(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                _hero.Interact();
            }
        }

        public void OnAttackPerformed(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                _hero.Attack();
            }
        }

        public void OnThrowPerformed(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                _hero.Throw();
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
            _inputActions.Disable();
        }
    }
}