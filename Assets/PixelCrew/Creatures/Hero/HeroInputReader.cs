using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.PixelCrew.Creatures.Hero
{
    public class HeroInputReader : MonoBehaviour
    {
        [SerializeField]
        private Hero _hero;
        private HeroInputActions _inputActions;

        private float _throwPerformed;

        private void Awake()
        {
            _inputActions = new HeroInputActions();
        }

        private void OnEnable()
        {
            _inputActions.Enable();
        }

        public void OnInteractPerformed(InputAction.CallbackContext context)
        {
            if (_hero.IsDead)
            {
                return;
            }

            if (context.performed)
            {
                _hero.Interact();
            }
        }

        public void OnAttackPerformed(InputAction.CallbackContext context)
        {
            if (_hero.IsDead)
            {
                return;
            }

            if (context.performed)
            {
                _hero.Attack();
            }
        }

        public void OnThrowPerformed(InputAction.CallbackContext context)
        {
            if (_hero.IsDead)
            {
                return;
            }

            if (context.performed)
            {
                _throwPerformed = Time.time;
            }

            if (context.canceled)
            {
                if (_throwPerformed + 1 < Time.time)
                {
                    _hero.Throw(true);
                }
                else
                {
                    _hero.Throw();
                }
            }
        }

        public void OnAxisMovement(InputAction.CallbackContext callbackContext)
        {
            if (_hero.IsDead)
            {
                return;
            }

            var direction = callbackContext.ReadValue<Vector2>();
            _hero.SetDirection(direction);
        }

        public void OnUseHealthPotion(InputAction.CallbackContext context)
        {
            if (_hero.IsDead)
            {
                return;
            }

            Debug.Log("Use health potion");

            if (context.performed)
            {
                Debug.Log("Used health potion");

                _hero.UseHealthPotion();
            }
        }

        private void OnDisable()
        {
            _inputActions.Disable();
        }
    }
}