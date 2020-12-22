// GENERATED AUTOMATICALLY FROM 'Assets/inputs.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Inputs : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Inputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""inputs"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""e4bc18fc-f9a7-4315-b0c1-4f867dd34c21"",
            ""actions"": [
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""6480349e-1e4f-44d2-b6df-58815cad6456"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Mov"",
                    ""type"": ""Button"",
                    ""id"": ""6c9e7c06-987f-4f06-901a-dc5512819b46"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""espada"",
                    ""type"": ""Button"",
                    ""id"": ""573c682c-2427-4941-b9d0-68e007c00676"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""UseItem"",
                    ""type"": ""Button"",
                    ""id"": ""045451fe-c676-4600-995e-63914ccd8d3b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Inventory"",
                    ""type"": ""Button"",
                    ""id"": ""e623bfd7-bd67-44c1-a8aa-e443d38182a5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""attack"",
                    ""type"": ""Button"",
                    ""id"": ""c58bde6d-8971-4d4b-8727-1c143811b208"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""32cb50c7-b8af-4d4b-9e15-d5be02863e34"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": ""Press(pressPoint=0.2,behavior=2)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4b85f0a0-950a-410d-a2c4-3e4da0a41eed"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": ""Press(pressPoint=0.2,behavior=2)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Horizontal"",
                    ""id"": ""f0270e88-fed7-4295-9a46-7cda2214bd15"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mov"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""e2fbcdaf-7f20-4025-8043-1b99446d2631"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mov"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""343ed9de-bacc-4f76-a894-181bf7629455"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mov"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Horizontal2"",
                    ""id"": ""1e3f6406-595f-4d1a-af3b-a094d2baa954"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mov"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""b41bd976-0a2a-42d6-987b-046600daa967"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mov"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""4d5e8c02-4003-484d-8805-90421b6ad85f"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mov"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Horizontal3"",
                    ""id"": ""710ac524-b5b6-4b3a-b2a9-39e9cceb0232"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mov"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""5c2e044a-2155-4d44-a132-0ab1a760033f"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mov"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""2845e109-7ae1-4c28-a00d-8eeebb34b8c6"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mov"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""bd7ddc7b-62d5-4687-865c-b2f05234ae0c"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": ""Press(pressPoint=0.1)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""espada"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ebe38a57-f8d2-47d8-a951-58a593bb4516"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": ""Press(pressPoint=0.1)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""espada"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2fefaccf-e345-464f-802c-bec5d095c941"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": ""Press(pressPoint=0.5)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UseItem"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b9542746-a8c6-4556-9650-7bd165ed85ab"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Inventory"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3a847d40-041f-4306-94b1-b1fe014cfb4e"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Jump = m_Player.FindAction("Jump", throwIfNotFound: true);
        m_Player_Mov = m_Player.FindAction("Mov", throwIfNotFound: true);
        m_Player_espada = m_Player.FindAction("espada", throwIfNotFound: true);
        m_Player_UseItem = m_Player.FindAction("UseItem", throwIfNotFound: true);
        m_Player_Inventory = m_Player.FindAction("Inventory", throwIfNotFound: true);
        m_Player_attack = m_Player.FindAction("attack", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Jump;
    private readonly InputAction m_Player_Mov;
    private readonly InputAction m_Player_espada;
    private readonly InputAction m_Player_UseItem;
    private readonly InputAction m_Player_Inventory;
    private readonly InputAction m_Player_attack;
    public struct PlayerActions
    {
        private @Inputs m_Wrapper;
        public PlayerActions(@Inputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Jump => m_Wrapper.m_Player_Jump;
        public InputAction @Mov => m_Wrapper.m_Player_Mov;
        public InputAction @espada => m_Wrapper.m_Player_espada;
        public InputAction @UseItem => m_Wrapper.m_Player_UseItem;
        public InputAction @Inventory => m_Wrapper.m_Player_Inventory;
        public InputAction @attack => m_Wrapper.m_Player_attack;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Jump.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Mov.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMov;
                @Mov.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMov;
                @Mov.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMov;
                @espada.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnEspada;
                @espada.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnEspada;
                @espada.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnEspada;
                @UseItem.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnUseItem;
                @UseItem.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnUseItem;
                @UseItem.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnUseItem;
                @Inventory.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInventory;
                @Inventory.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInventory;
                @Inventory.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInventory;
                @attack.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttack;
                @attack.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttack;
                @attack.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttack;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Mov.started += instance.OnMov;
                @Mov.performed += instance.OnMov;
                @Mov.canceled += instance.OnMov;
                @espada.started += instance.OnEspada;
                @espada.performed += instance.OnEspada;
                @espada.canceled += instance.OnEspada;
                @UseItem.started += instance.OnUseItem;
                @UseItem.performed += instance.OnUseItem;
                @UseItem.canceled += instance.OnUseItem;
                @Inventory.started += instance.OnInventory;
                @Inventory.performed += instance.OnInventory;
                @Inventory.canceled += instance.OnInventory;
                @attack.started += instance.OnAttack;
                @attack.performed += instance.OnAttack;
                @attack.canceled += instance.OnAttack;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    public interface IPlayerActions
    {
        void OnJump(InputAction.CallbackContext context);
        void OnMov(InputAction.CallbackContext context);
        void OnEspada(InputAction.CallbackContext context);
        void OnUseItem(InputAction.CallbackContext context);
        void OnInventory(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
    }
}
