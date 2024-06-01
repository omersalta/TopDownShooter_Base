using System;
using UnityEngine;

namespace _Scripts.Items.CollectableItems
{
    public abstract class CollectorBase : MonoBehaviour
    {
        public abstract void OnTriggerEnter(Collider other);

    }
}