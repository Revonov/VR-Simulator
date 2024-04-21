using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;

namespace InputSystemTouchScreen
{
    public class TouchscreenGameplayInput
    {
        public event Action<Vector2> RotationInputReceived;

        private readonly InputMap _inputMap;

        public TouchscreenGameplayInput(InputMap inputMap)
        {
            _inputMap = inputMap;

            _inputMap.TouchScreen.TouchDelta.performed += OnTouchDeltaPerformed;
        }

        private void OnTouchDeltaPerformed(InputAction.CallbackContext context)
        {
            RotationInputReceived?.Invoke(context.ReadValue<Vector2>());
        }

    }
}
