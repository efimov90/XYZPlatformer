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
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""18fcd924-72f8-4047-83bd-64872c8a2259"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""22c22c3e-ce32-475d-bef5-43fc334dba13"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Throw"",
                    ""type"": ""Button"",
                    ""id"": ""46530e6a-03ac-4246-862d-fa2524f0f5db"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""UseHealthPotion"",
                    ""type"": ""Button"",
                    ""id"": ""cd7b494f-db51-461d-9512-90aa5c860093"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""NextQuickItem"",
                    ""type"": ""Button"",
                    ""id"": ""7e3ef684-d346-4c9c-9f99-dd593177f03f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""OpenInventory"",
                    ""type"": ""Button"",
                    ""id"": ""57f63de6-d212-434a-bdb9-bd9bc88a2580"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""f866e183-3663-4f92-b1e9-ad3580c3e994"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ToggleLight"",
                    ""type"": ""Button"",
                    ""id"": ""6a127ee4-1f92-47d9-af14-8b118383a47b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
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
                },
                {
                    ""name"": """",
                    ""id"": ""c1edd48b-0703-4a98-b46e-626df3c3778d"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""15ad7726-01a1-4b5b-b1a5-e38b5598c250"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bb1d0257-54f7-46fa-bcaf-2dd967aae10a"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Throw"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""93645b60-fbc3-4464-94ca-602ae66ab0f3"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UseHealthPotion"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ef8ab2b7-cf3f-4d52-9e44-d33df75de127"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NextQuickItem"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ee81967b-74ec-428b-95ee-5a17615b4a99"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OpenInventory"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e62a28d9-079a-4d6d-8713-cd970f3ed23e"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ac3e745f-ad42-4ca6-87c0-340f33cd5443"",
                    ""path"": ""<Keyboard>/l"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ToggleLight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Hero
        m_Hero = asset.FindActionMap("Hero", throwIfNotFound: true);
        m_Hero_AxisMovement = m_Hero.FindAction("AxisMovement", throwIfNotFound: true);
        m_Hero_Interact = m_Hero.FindAction("Interact", throwIfNotFound: true);
        m_Hero_Attack = m_Hero.FindAction("Attack", throwIfNotFound: true);
        m_Hero_Throw = m_Hero.FindAction("Throw", throwIfNotFound: true);
        m_Hero_UseHealthPotion = m_Hero.FindAction("UseHealthPotion", throwIfNotFound: true);
        m_Hero_NextQuickItem = m_Hero.FindAction("NextQuickItem", throwIfNotFound: true);
        m_Hero_OpenInventory = m_Hero.FindAction("OpenInventory", throwIfNotFound: true);
        m_Hero_Dash = m_Hero.FindAction("Dash", throwIfNotFound: true);
        m_Hero_ToggleLight = m_Hero.FindAction("ToggleLight", throwIfNotFound: true);
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
    private readonly InputAction m_Hero_Interact;
    private readonly InputAction m_Hero_Attack;
    private readonly InputAction m_Hero_Throw;
    private readonly InputAction m_Hero_UseHealthPotion;
    private readonly InputAction m_Hero_NextQuickItem;
    private readonly InputAction m_Hero_OpenInventory;
    private readonly InputAction m_Hero_Dash;
    private readonly InputAction m_Hero_ToggleLight;
    public struct HeroActions
    {
        private @HeroInputActions m_Wrapper;
        public HeroActions(@HeroInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @AxisMovement => m_Wrapper.m_Hero_AxisMovement;
        public InputAction @Interact => m_Wrapper.m_Hero_Interact;
        public InputAction @Attack => m_Wrapper.m_Hero_Attack;
        public InputAction @Throw => m_Wrapper.m_Hero_Throw;
        public InputAction @UseHealthPotion => m_Wrapper.m_Hero_UseHealthPotion;
        public InputAction @NextQuickItem => m_Wrapper.m_Hero_NextQuickItem;
        public InputAction @OpenInventory => m_Wrapper.m_Hero_OpenInventory;
        public InputAction @Dash => m_Wrapper.m_Hero_Dash;
        public InputAction @ToggleLight => m_Wrapper.m_Hero_ToggleLight;
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
                @Interact.started -= m_Wrapper.m_HeroActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_HeroActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_HeroActionsCallbackInterface.OnInteract;
                @Attack.started -= m_Wrapper.m_HeroActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_HeroActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_HeroActionsCallbackInterface.OnAttack;
                @Throw.started -= m_Wrapper.m_HeroActionsCallbackInterface.OnThrow;
                @Throw.performed -= m_Wrapper.m_HeroActionsCallbackInterface.OnThrow;
                @Throw.canceled -= m_Wrapper.m_HeroActionsCallbackInterface.OnThrow;
                @UseHealthPotion.started -= m_Wrapper.m_HeroActionsCallbackInterface.OnUseHealthPotion;
                @UseHealthPotion.performed -= m_Wrapper.m_HeroActionsCallbackInterface.OnUseHealthPotion;
                @UseHealthPotion.canceled -= m_Wrapper.m_HeroActionsCallbackInterface.OnUseHealthPotion;
                @NextQuickItem.started -= m_Wrapper.m_HeroActionsCallbackInterface.OnNextQuickItem;
                @NextQuickItem.performed -= m_Wrapper.m_HeroActionsCallbackInterface.OnNextQuickItem;
                @NextQuickItem.canceled -= m_Wrapper.m_HeroActionsCallbackInterface.OnNextQuickItem;
                @OpenInventory.started -= m_Wrapper.m_HeroActionsCallbackInterface.OnOpenInventory;
                @OpenInventory.performed -= m_Wrapper.m_HeroActionsCallbackInterface.OnOpenInventory;
                @OpenInventory.canceled -= m_Wrapper.m_HeroActionsCallbackInterface.OnOpenInventory;
                @Dash.started -= m_Wrapper.m_HeroActionsCallbackInterface.OnDash;
                @Dash.performed -= m_Wrapper.m_HeroActionsCallbackInterface.OnDash;
                @Dash.canceled -= m_Wrapper.m_HeroActionsCallbackInterface.OnDash;
                @ToggleLight.started -= m_Wrapper.m_HeroActionsCallbackInterface.OnToggleLight;
                @ToggleLight.performed -= m_Wrapper.m_HeroActionsCallbackInterface.OnToggleLight;
                @ToggleLight.canceled -= m_Wrapper.m_HeroActionsCallbackInterface.OnToggleLight;
            }
            m_Wrapper.m_HeroActionsCallbackInterface = instance;
            if (instance != null)
            {
                @AxisMovement.started += instance.OnAxisMovement;
                @AxisMovement.performed += instance.OnAxisMovement;
                @AxisMovement.canceled += instance.OnAxisMovement;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
                @Throw.started += instance.OnThrow;
                @Throw.performed += instance.OnThrow;
                @Throw.canceled += instance.OnThrow;
                @UseHealthPotion.started += instance.OnUseHealthPotion;
                @UseHealthPotion.performed += instance.OnUseHealthPotion;
                @UseHealthPotion.canceled += instance.OnUseHealthPotion;
                @NextQuickItem.started += instance.OnNextQuickItem;
                @NextQuickItem.performed += instance.OnNextQuickItem;
                @NextQuickItem.canceled += instance.OnNextQuickItem;
                @OpenInventory.started += instance.OnOpenInventory;
                @OpenInventory.performed += instance.OnOpenInventory;
                @OpenInventory.canceled += instance.OnOpenInventory;
                @Dash.started += instance.OnDash;
                @Dash.performed += instance.OnDash;
                @Dash.canceled += instance.OnDash;
                @ToggleLight.started += instance.OnToggleLight;
                @ToggleLight.performed += instance.OnToggleLight;
                @ToggleLight.canceled += instance.OnToggleLight;
            }
        }
    }
    public HeroActions @Hero => new HeroActions(this);
    public interface IHeroActions
    {
        void OnAxisMovement(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnThrow(InputAction.CallbackContext context);
        void OnUseHealthPotion(InputAction.CallbackContext context);
        void OnNextQuickItem(InputAction.CallbackContext context);
        void OnOpenInventory(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
        void OnToggleLight(InputAction.CallbackContext context);
    }
}
