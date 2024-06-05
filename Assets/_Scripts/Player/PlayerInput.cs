using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace _Scripts.Player
{
    public class PlayerInput : MonoBehaviour
    {
        public static readonly KeyCode[] InventoryKeys = {UnityEngine.KeyCode.Alpha1, UnityEngine.KeyCode.Alpha2, UnityEngine.KeyCode.Alpha3, UnityEngine.KeyCode.Alpha4, UnityEngine.KeyCode.Alpha5};
        
        public static Vector3 PlayerMouseCursor;
        public float SpeedX;
        public float SpeedY;
        public UnityEvent MouseDownEvent; public UnityEvent MouseUpEvent; public UnityEvent<KeyCode> KeyCode ;
        public UnityEvent MousePressedEvent;

        public bool isActive = true;
        
        
        private Camera _mainCamera;
        [SerializeField] private LayerMask _groundMask;
        
        private void SetMouseCursor()
        {
            //Code copied from there https://github.com/BarthaSzabolcs/Tutorial-IsometricAiming/blob/main/Assets/Scripts/Simple%20-%20CopyThis/IsometricAiming.cs
            var (success, position) = GetMousePosition();
            if (success)
            {
                PlayerMouseCursor = position;
            }
        }

        private (bool success, Vector3 position) GetMousePosition()
        {
            var ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out var hitInfo, Mathf.Infinity, _groundMask))
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
        
        
        private void Start()
        {
            _mainCamera = Camera.main;
            SetAsDefault();
            
        }

        void Update()
        {
            if (!isActive)
            {
                SetAsDefault();
                return;
            }
            
            //Move
            SpeedX = Input.GetAxisRaw("Horizontal");
            SpeedY = Input.GetAxisRaw("Vertical");
            
            //Aim
            SetMouseCursor();
           
            //Fire
            if (Input.GetMouseButtonDown(0))
            {
                MouseDownEvent.Invoke();
            }else if (Input.GetMouseButtonUp(0)) {
                MouseUpEvent.Invoke();
            }
            
            //inventory
            foreach (KeyCode key in InventoryKeys)
            {
                if(Input.GetKeyDown(key)) KeyCode.Invoke(key);
            }
            
        }
    
        void SetAsDefault()
        {
            SpeedX = 0;
            SpeedY = 0;
        }
    }
}
