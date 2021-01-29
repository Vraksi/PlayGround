// GENERATED AUTOMATICALLY FROM 'Assets/LaserDefender/Script/PlayerShipControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerShipControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerShipControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerShipControls"",
    ""maps"": [
        {
            ""name"": ""Move"",
            ""id"": ""a789335c-feca-4849-b8ce-686a31158056"",
            ""actions"": [
                {
                    ""name"": ""Horizontal"",
                    ""type"": ""PassThrough"",
                    ""id"": ""76838051-b699-4380-b0c3-6abc775ed700"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Vertical"",
                    ""type"": ""PassThrough"",
                    ""id"": ""2fd33c07-d04c-4a03-9324-7c77ed099582"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Fire"",
                    ""type"": ""PassThrough"",
                    ""id"": ""ab501a4b-9674-46e1-bbfe-4113ba83bf2c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""LeftRight"",
                    ""id"": ""e4b8dd04-1dcb-4130-be1f-55e36e99db89"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""55ae1870-5226-4a08-b59b-bffdd41ddd2a"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""22825813-d4a6-4274-9081-15e664107565"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""UpDown"",
                    ""id"": ""eb456ea9-e0ae-4115-8d3c-0ac67b285a12"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Vertical"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""73c76d97-de9d-4e87-b383-11a5186c1d4f"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Vertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""db628318-8612-47be-b75b-154ec79fd898"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Vertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""29c40dbd-fe66-4f19-ad37-bed02303709f"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Move
        m_Move = asset.FindActionMap("Move", throwIfNotFound: true);
        m_Move_Horizontal = m_Move.FindAction("Horizontal", throwIfNotFound: true);
        m_Move_Vertical = m_Move.FindAction("Vertical", throwIfNotFound: true);
        m_Move_Fire = m_Move.FindAction("Fire", throwIfNotFound: true);
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

    // Move
    private readonly InputActionMap m_Move;
    private IMoveActions m_MoveActionsCallbackInterface;
    private readonly InputAction m_Move_Horizontal;
    private readonly InputAction m_Move_Vertical;
    private readonly InputAction m_Move_Fire;
    public struct MoveActions
    {
        private @PlayerShipControls m_Wrapper;
        public MoveActions(@PlayerShipControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Horizontal => m_Wrapper.m_Move_Horizontal;
        public InputAction @Vertical => m_Wrapper.m_Move_Vertical;
        public InputAction @Fire => m_Wrapper.m_Move_Fire;
        public InputActionMap Get() { return m_Wrapper.m_Move; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MoveActions set) { return set.Get(); }
        public void SetCallbacks(IMoveActions instance)
        {
            if (m_Wrapper.m_MoveActionsCallbackInterface != null)
            {
                @Horizontal.started -= m_Wrapper.m_MoveActionsCallbackInterface.OnHorizontal;
                @Horizontal.performed -= m_Wrapper.m_MoveActionsCallbackInterface.OnHorizontal;
                @Horizontal.canceled -= m_Wrapper.m_MoveActionsCallbackInterface.OnHorizontal;
                @Vertical.started -= m_Wrapper.m_MoveActionsCallbackInterface.OnVertical;
                @Vertical.performed -= m_Wrapper.m_MoveActionsCallbackInterface.OnVertical;
                @Vertical.canceled -= m_Wrapper.m_MoveActionsCallbackInterface.OnVertical;
                @Fire.started -= m_Wrapper.m_MoveActionsCallbackInterface.OnFire;
                @Fire.performed -= m_Wrapper.m_MoveActionsCallbackInterface.OnFire;
                @Fire.canceled -= m_Wrapper.m_MoveActionsCallbackInterface.OnFire;
            }
            m_Wrapper.m_MoveActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Horizontal.started += instance.OnHorizontal;
                @Horizontal.performed += instance.OnHorizontal;
                @Horizontal.canceled += instance.OnHorizontal;
                @Vertical.started += instance.OnVertical;
                @Vertical.performed += instance.OnVertical;
                @Vertical.canceled += instance.OnVertical;
                @Fire.started += instance.OnFire;
                @Fire.performed += instance.OnFire;
                @Fire.canceled += instance.OnFire;
            }
        }
    }
    public MoveActions @Move => new MoveActions(this);
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    public interface IMoveActions
    {
        void OnHorizontal(InputAction.CallbackContext context);
        void OnVertical(InputAction.CallbackContext context);
        void OnFire(InputAction.CallbackContext context);
    }
}
