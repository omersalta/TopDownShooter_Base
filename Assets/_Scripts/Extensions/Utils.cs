using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace _Scripts.Extensions
{
    public class Utils
    {
        public static Vector3 GetMouseWorldPosition() {
            Vector3 vec = GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
            vec.z = 0f;
            return vec;
        }

        public static Vector3 GetMouseWorldPositionWithZ() {
            return GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
        }

        public static Vector3 GetMouseWorldPositionWithZ(Camera worldCamera) {
            return GetMouseWorldPositionWithZ(Input.mousePosition, worldCamera);
        }

        public static Vector3 GetMouseWorldPositionWithZ(Vector3 screenPosition, Camera worldCamera) {
            Vector3 worldPosition = worldCamera.ScreenToWorldPoint(screenPosition);
            return worldPosition;
        }

        public static Vector3 GetDirToMouse(Vector3 fromPosition) {
            Vector3 mouseWorldPosition = GetMouseWorldPosition();
            return (mouseWorldPosition - fromPosition).normalized;
        }
        
        
    }
    
    public static class StaticUtils 
    {
        
        public static void Wait (this MonoBehaviour mono, float delay, UnityAction action) {
            mono.StartCoroutine (ExecuteAction (delay, action)) ;
        }

        private static IEnumerator ExecuteAction (float delay, UnityAction action) {
            yield return new WaitForSecondsRealtime (delay) ;
            action.Invoke () ;
        }
    }
   
}