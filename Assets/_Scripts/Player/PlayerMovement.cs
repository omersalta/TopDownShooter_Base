using System;
using _Scripts.Extensions;
using _Scripts.Player.InventoryItems;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Scripts.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        private Rigidbody _rigidbody;
        private PlayerInput _input;
        
        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _input = GetComponent<PlayerInput>();
        }

        private void Update()
        {
            _rigidbody.velocity = (new Vector3(_input.SpeedX, 0, _input.SpeedY) * 14);
            Aim();
        }
        
        private void Aim()
        {
            // Calculate the direction
            Vector3 aimVector = PlayerInput.PlayerMouseCursor - transform.position;
            // You might want to delete this line.
            // Ignore the height difference.
            aimVector.y = 0;

            // Make the transform look in the direction.
            transform.forward = aimVector;
        }
        
    }
}