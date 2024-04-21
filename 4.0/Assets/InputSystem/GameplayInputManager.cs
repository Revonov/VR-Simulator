using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace InputSystemTouchScreen
{
    public class GameplayInputManager : MonoBehaviour
    {
        public event Action<Vector2> RotationInputReceived;

        private InputMap _inputMap;
        private TouchscreenGameplayInput _touchscreenInput;

        private void Awake()
        {
            _inputMap = new InputMap();

            _inputMap.Enable();

            InitTouchscreenInput(_inputMap);
        }

        private void InitTouchscreenInput(InputMap inputmap)
        {
            _touchscreenInput = new TouchscreenGameplayInput(inputmap);

            _touchscreenInput.RotationInputReceived += OnRotationInputRecieved;
        }

        private void OnRotationInputRecieved(Vector2 delta)
        {
            RotationInputReceived?.Invoke(delta);
        }
    }
}
