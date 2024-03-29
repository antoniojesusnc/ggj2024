//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Scripts/Player/PlayerInput/PlayerInputs.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerInputs: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputs"",
    ""maps"": [
        {
            ""name"": ""Clown P1"",
            ""id"": ""49a99eab-9e44-46d0-8df4-8c078eea4169"",
            ""actions"": [
                {
                    ""name"": ""AlternatingPrimary"",
                    ""type"": ""Button"",
                    ""id"": ""38dafffd-3f36-4a51-9940-b6b46424ec40"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""AlternatingSecondary"",
                    ""type"": ""Button"",
                    ""id"": ""3b6c28d3-d764-47ef-b871-993b80b04bc0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Join"",
                    ""type"": ""Button"",
                    ""id"": ""347e30ed-6059-42db-b9a7-22b2ce5aaeeb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""549c2d0b-8b45-48d9-9487-90826551b598"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AlternatingPrimary"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c131e9ee-c2f5-4086-964a-63537abc5a27"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AlternatingPrimary"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""068af402-9143-49cb-8feb-a30fc04c43c1"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AlternatingPrimary"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""83b9a77a-1c24-42ff-bc27-d7fcc9c2e854"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AlternatingSecondary"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2a12e145-04cc-4624-aa34-721c1585de93"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AlternatingSecondary"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""95c93a46-9b22-487f-b275-ed71f8b81c31"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AlternatingSecondary"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d3359d4c-6257-4d95-aaaa-80c7b077fc6b"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Join"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dab3554f-365c-4875-811b-cfe28643f8b7"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Join"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""46ff0183-377f-4ebf-8687-400714a03104"",
                    ""path"": ""<Mouse>/middleButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Join"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Clown P1
        m_ClownP1 = asset.FindActionMap("Clown P1", throwIfNotFound: true);
        m_ClownP1_AlternatingPrimary = m_ClownP1.FindAction("AlternatingPrimary", throwIfNotFound: true);
        m_ClownP1_AlternatingSecondary = m_ClownP1.FindAction("AlternatingSecondary", throwIfNotFound: true);
        m_ClownP1_Join = m_ClownP1.FindAction("Join", throwIfNotFound: true);
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

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Clown P1
    private readonly InputActionMap m_ClownP1;
    private List<IClownP1Actions> m_ClownP1ActionsCallbackInterfaces = new List<IClownP1Actions>();
    private readonly InputAction m_ClownP1_AlternatingPrimary;
    private readonly InputAction m_ClownP1_AlternatingSecondary;
    private readonly InputAction m_ClownP1_Join;
    public struct ClownP1Actions
    {
        private @PlayerInputs m_Wrapper;
        public ClownP1Actions(@PlayerInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @AlternatingPrimary => m_Wrapper.m_ClownP1_AlternatingPrimary;
        public InputAction @AlternatingSecondary => m_Wrapper.m_ClownP1_AlternatingSecondary;
        public InputAction @Join => m_Wrapper.m_ClownP1_Join;
        public InputActionMap Get() { return m_Wrapper.m_ClownP1; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ClownP1Actions set) { return set.Get(); }
        public void AddCallbacks(IClownP1Actions instance)
        {
            if (instance == null || m_Wrapper.m_ClownP1ActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_ClownP1ActionsCallbackInterfaces.Add(instance);
            @AlternatingPrimary.started += instance.OnAlternatingPrimary;
            @AlternatingPrimary.performed += instance.OnAlternatingPrimary;
            @AlternatingPrimary.canceled += instance.OnAlternatingPrimary;
            @AlternatingSecondary.started += instance.OnAlternatingSecondary;
            @AlternatingSecondary.performed += instance.OnAlternatingSecondary;
            @AlternatingSecondary.canceled += instance.OnAlternatingSecondary;
            @Join.started += instance.OnJoin;
            @Join.performed += instance.OnJoin;
            @Join.canceled += instance.OnJoin;
        }

        private void UnregisterCallbacks(IClownP1Actions instance)
        {
            @AlternatingPrimary.started -= instance.OnAlternatingPrimary;
            @AlternatingPrimary.performed -= instance.OnAlternatingPrimary;
            @AlternatingPrimary.canceled -= instance.OnAlternatingPrimary;
            @AlternatingSecondary.started -= instance.OnAlternatingSecondary;
            @AlternatingSecondary.performed -= instance.OnAlternatingSecondary;
            @AlternatingSecondary.canceled -= instance.OnAlternatingSecondary;
            @Join.started -= instance.OnJoin;
            @Join.performed -= instance.OnJoin;
            @Join.canceled -= instance.OnJoin;
        }

        public void RemoveCallbacks(IClownP1Actions instance)
        {
            if (m_Wrapper.m_ClownP1ActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IClownP1Actions instance)
        {
            foreach (var item in m_Wrapper.m_ClownP1ActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_ClownP1ActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public ClownP1Actions @ClownP1 => new ClownP1Actions(this);
    public interface IClownP1Actions
    {
        void OnAlternatingPrimary(InputAction.CallbackContext context);
        void OnAlternatingSecondary(InputAction.CallbackContext context);
        void OnJoin(InputAction.CallbackContext context);
    }
}
