using UnityEngine;
using UnityEngine.Events;

namespace _Scripts.Player
{
    public class PlayerInput : MonoBehaviour
    {
        public static readonly KeyCode[] inventoryKeys = {KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4, KeyCode.Alpha5};
        
        public static Vector3 PlayerMouseCursor;
        public float SpeedX, SpeedY;
        public UnityEvent mouseDownEvent; public UnityEvent mouseUpEvent; public UnityEvent<KeyCode> keyCode ;
        
        
        private Camera _mainCamera;
        [SerializeField] private LayerMask groundMask;
        
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
        
        
        private void Start()
        {
            _mainCamera = Camera.main;
            SetAsDefault();
        }

        void Update()
        {
            //Move
            SpeedX = Input.GetAxisRaw("Horizontal");
            SpeedY = Input.GetAxisRaw("Vertical");
            
            //Aim
            SetMouseCursor();
           
            //Fire
            if (Input.GetMouseButtonDown(0))
            {
                mouseDownEvent.Invoke();
            }else if (Input.GetMouseButtonUp(0)) {
                mouseUpEvent.Invoke();
            }
            
            //inventory
            foreach (KeyCode _key in inventoryKeys)
            {
                if(Input.GetKeyDown(_key)) keyCode.Invoke(_key);
            }
            
        }
    
        void SetAsDefault()
        {
            SpeedX = 0;
            SpeedY = 0;
        }
    }
}
