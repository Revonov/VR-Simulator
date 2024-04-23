using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InputSystemTouchScreen
{
    public class CameraRotationHandler : MonoBehaviour
    {
        [SerializeField] private GameplayInputManager _inputManager;

        [SerializeField] private Transform _rotationTarget;
        [SerializeField] private float _sensitivity = 1.0f;

        private float _horizontal = 0f;
        private float _vertical = 0f;

        private void Start()
        {
            _inputManager.RotationInputReceived += OnRotationInputRecieved;
        }

        private void OnDestroy()
        {
            _inputManager.RotationInputReceived -= OnRotationInputRecieved;
        }

        private void OnRotationInputRecieved(Vector2 delta)
        {
            var dt = Time.deltaTime;

            _vertical -= _sensitivity * delta.y * dt;
            _horizontal += _sensitivity * delta.x * dt;

            _rotationTarget.eulerAngles = new Vector3(_vertical, _horizontal, 0f);
        }
    }
}

