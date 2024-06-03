using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace _Scripts.Extensions
{
    public static class Utils
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