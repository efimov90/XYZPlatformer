using System;
using UnityEngine;
using UnityEngine.InputSystem;

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
        _inputActions.Hero.SaySomething.canceled += OnSaySomethingCanceled;
        _inputActions.Enable();
    }

    private void OnSaySomethingCanceled(InputAction.CallbackContext context)
    {
        _hero.SaySomething();
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
        _inputActions.Hero.SaySomething.canceled -= OnSaySomethingCanceled;
        _inputActions.Disable();
    }
}
