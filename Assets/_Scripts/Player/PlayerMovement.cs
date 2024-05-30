using System;
using _Scripts.Extensions;
using UnityEngine;

namespace _Scripts.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        private Rigidbody _rigidbody;
        private PlayerInput _input;
        private Camera _mainCamera;
        [SerializeField] private LayerMask groundMask;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _input = GetComponent<PlayerInput>();
            _mainCamera = Camera.main;
        }

        private void Update()
        {
            _rigidbody.velocity = (new Vector3(_input.SpeedX, 0, _input.SpeedY) * 25);
            Aim();
        }
        
        private void Aim()
        {
            var (success, position) = GetMousePosition();
            if (success)
            {
                // Calculate the direction
                var direction = position - transform.position;

                // You might want to delete this line.
                // Ignore the height difference.
                direction.y = 0;

                // Make the transform look in the direction.
                transform.forward = direction;
            }
        }

        private (bool success, Vector3 position) GetMousePosition()
        {
            var ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out var hitInfo, Mathf.Infinity, groundMask))
            {
                // The Raycast hit something, return with the position.
                return (success: true, position: hitInfo.point);
            }
            else
            {
                // The Raycast did not hit anything.
                return (success: false, position: Vector3.zero);
            }
        }
    }
}