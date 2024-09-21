// GENERATED AUTOMATICALLY FROM 'Assets/UserInput/InputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @HeroInputActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @HeroInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputActions"",
    ""maps"": [
        {
            ""name"": ""Hero"",
            ""id"": ""fbef9958-58bd-4d31-86f2-1264e1154f08"",
            ""actions"": [
                {
                    ""name"": ""AxisMovement"",
                    ""type"": ""Value"",
                    ""id"": ""c491b536-eb61-40ea-9baf-c8df0e79908a"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SaySomething"",
                    ""type"": ""Button"",
                    ""id"": ""078b1c06-75e8-42cc-9e3a-c5607da45174"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""eab52909-5873-4c81-9e04-fedfa29bcfaa"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SaySomething"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""edc3de1d-cb1f-4e11-bb70-5d2b9de9d337"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AxisMovement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""ea589397-70ca-4aed-bf10-d901382b58f1"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AxisMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""d892cc5c-aca3-4b68-909d-577ffd22c761"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AxisMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""cfe7862d-bb0c-4b98-988f-47bb323b96c5"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AxisMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""f1aa8253-a1ef-4aa9-9f26-c3e278c107df"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AxisMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""c6549d8b-3ba2-485f-816e-248b34cdbe6f"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AxisMovement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""d7537231-256f-4774-8b1e-d73887c3b7b1"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AxisMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""f667613c-8e89-45ec-9feb-66127a70d5a0"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AxisMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""03210fc4-d479-43ba-bbed-604ccfc909ba"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AxisMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""b4f58faf-aaea-4a87-b928-e399c2106f2c"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AxisMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Hero
        m_Hero = asset.FindActionMap("Hero", throwIfNotFound: true);
        m_Hero_AxisMovement = m_Hero.FindAction("AxisMovement", throwIfNotFound: true);
        m_Hero_SaySomething = m_Hero.FindAction("SaySomething", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Hero
    private readonly InputActionMap m_Hero;
    private IHeroActions m_HeroActionsCallbackInterface;
    private readonly InputAction m_Hero_AxisMovement;
    private readonly InputAction m_Hero_SaySomething;
    public struct HeroActions
    {
        private @HeroInputActions m_Wrapper;
        public HeroActions(@HeroInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @AxisMovement => m_Wrapper.m_Hero_AxisMovement;
        public InputAction @SaySomething => m_Wrapper.m_Hero_SaySomething;
        public InputActionMap Get() { return m_Wrapper.m_Hero; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(HeroActions set) { return set.Get(); }
        public void SetCallbacks(IHeroActions instance)
        {
            if (m_Wrapper.m_HeroActionsCallbackInterface != null)
            {
                @AxisMovement.started -= m_Wrapper.m_HeroActionsCallbackInterface.OnAxisMovement;
                @AxisMovement.performed -= m_Wrapper.m_HeroActionsCallbackInterface.OnAxisMovement;
                @AxisMovement.canceled -= m_Wrapper.m_HeroActionsCallbackInterface.OnAxisMovement;
                @SaySomething.started -= m_Wrapper.m_HeroActionsCallbackInterface.OnSaySomething;
                @SaySomething.performed -= m_Wrapper.m_HeroActionsCallbackInterface.OnSaySomething;
                @SaySomething.canceled -= m_Wrapper.m_HeroActionsCallbackInterface.OnSaySomething;
            }
            m_Wrapper.m_HeroActionsCallbackInterface = instance;
            if (instance != null)
            {
                @AxisMovement.started += instance.OnAxisMovement;
                @AxisMovement.performed += instance.OnAxisMovement;
                @AxisMovement.canceled += instance.OnAxisMovement;
                @SaySomething.started += instance.OnSaySomething;
                @SaySomething.performed += instance.OnSaySomething;
                @SaySomething.canceled += instance.OnSaySomething;
            }
        }
    }
    public HeroActions @Hero => new HeroActions(this);
    public interface IHeroActions
    {
        void OnAxisMovement(InputAction.CallbackContext context);
        void OnSaySomething(InputAction.CallbackContext context);
    }
}
