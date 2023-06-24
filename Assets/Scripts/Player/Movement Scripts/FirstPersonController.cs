// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Player/Movement Scripts/FirstPersonController.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @FirstPersonController : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @FirstPersonController()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""FirstPersonController"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""01749c1d-9388-4335-b8df-47e7e1d0f539"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""b096aab9-84d2-41bf-b32c-c2aaf1704b6f"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""38f13ad4-ed43-48fa-8776-fbf0ef0a29be"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""PassThrough"",
                    ""id"": ""d7fdd543-8efb-4052-aa35-27c5e111a712"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Focus"",
                    ""type"": ""Button"",
                    ""id"": ""0b0b3996-b106-423b-b694-300dc363daa4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pill"",
                    ""type"": ""Button"",
                    ""id"": ""1d1bfc7c-814e-405c-b5db-f676e94ccad1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Run"",
                    ""type"": ""Value"",
                    ""id"": ""c52f6c25-450b-4cbb-aaca-e883612d6d7e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Mouse"",
                    ""type"": ""Button"",
                    ""id"": ""2bb893d8-a926-4c9a-a8b3-86810b287c8b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""UI"",
                    ""type"": ""Button"",
                    ""id"": ""40d2c26d-e460-412d-bf2e-9f4b70fee6bf"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""392d717f-d756-45d0-9c5a-a434e6ba5496"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""050887b5-32fb-4012-a4ab-1de06d4dbeee"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""5e811e5b-8373-41ca-b304-98b4bad256e5"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""1102edd7-a443-4a84-94ea-2ce01868d9af"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""27d61d16-8fbd-46b8-9dfa-5f10181148c5"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""40789471-d767-4abc-9e19-f2e7d392fa61"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""83c27440-80e7-4272-aa4f-17e299899cd8"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f0ea9b31-cf11-44c2-a17a-dbfe17b1863a"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Focus"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""03f9ff20-073b-4afe-84b9-f8296b46f387"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pill"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f17c843b-7d2b-483c-bc5a-3e84f5b950ef"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""32365714-5557-4973-a337-acce14b8a4df"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mouse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""426395ee-b54c-47f3-921f-4174e4d0c325"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UI"",
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
        m_Player_Movement = m_Player.FindAction("Movement", throwIfNotFound: true);
        m_Player_Jump = m_Player.FindAction("Jump", throwIfNotFound: true);
        m_Player_Look = m_Player.FindAction("Look", throwIfNotFound: true);
        m_Player_Focus = m_Player.FindAction("Focus", throwIfNotFound: true);
        m_Player_Pill = m_Player.FindAction("Pill", throwIfNotFound: true);
        m_Player_Run = m_Player.FindAction("Run", throwIfNotFound: true);
        m_Player_Mouse = m_Player.FindAction("Mouse", throwIfNotFound: true);
        m_Player_UI = m_Player.FindAction("UI", throwIfNotFound: true);
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
    private readonly InputAction m_Player_Movement;
    private readonly InputAction m_Player_Jump;
    private readonly InputAction m_Player_Look;
    private readonly InputAction m_Player_Focus;
    private readonly InputAction m_Player_Pill;
    private readonly InputAction m_Player_Run;
    private readonly InputAction m_Player_Mouse;
    private readonly InputAction m_Player_UI;
    public struct PlayerActions
    {
        private @FirstPersonController m_Wrapper;
        public PlayerActions(@FirstPersonController wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Player_Movement;
        public InputAction @Jump => m_Wrapper.m_Player_Jump;
        public InputAction @Look => m_Wrapper.m_Player_Look;
        public InputAction @Focus => m_Wrapper.m_Player_Focus;
        public InputAction @Pill => m_Wrapper.m_Player_Pill;
        public InputAction @Run => m_Wrapper.m_Player_Run;
        public InputAction @Mouse => m_Wrapper.m_Player_Mouse;
        public InputAction @UI => m_Wrapper.m_Player_UI;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Jump.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Look.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLook;
                @Look.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLook;
                @Look.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLook;
                @Focus.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFocus;
                @Focus.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFocus;
                @Focus.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFocus;
                @Pill.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPill;
                @Pill.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPill;
                @Pill.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPill;
                @Run.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRun;
                @Run.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRun;
                @Run.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRun;
                @Mouse.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMouse;
                @Mouse.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMouse;
                @Mouse.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMouse;
                @UI.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnUI;
                @UI.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnUI;
                @UI.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnUI;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Look.started += instance.OnLook;
                @Look.performed += instance.OnLook;
                @Look.canceled += instance.OnLook;
                @Focus.started += instance.OnFocus;
                @Focus.performed += instance.OnFocus;
                @Focus.canceled += instance.OnFocus;
                @Pill.started += instance.OnPill;
                @Pill.performed += instance.OnPill;
                @Pill.canceled += instance.OnPill;
                @Run.started += instance.OnRun;
                @Run.performed += instance.OnRun;
                @Run.canceled += instance.OnRun;
                @Mouse.started += instance.OnMouse;
                @Mouse.performed += instance.OnMouse;
                @Mouse.canceled += instance.OnMouse;
                @UI.started += instance.OnUI;
                @UI.performed += instance.OnUI;
                @UI.canceled += instance.OnUI;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    public interface IPlayerActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
        void OnFocus(InputAction.CallbackContext context);
        void OnPill(InputAction.CallbackContext context);
        void OnRun(InputAction.CallbackContext context);
        void OnMouse(InputAction.CallbackContext context);
        void OnUI(InputAction.CallbackContext context);
    }
}
