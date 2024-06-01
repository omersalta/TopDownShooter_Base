using _Scripts.Player;
using UnityEngine;

namespace _Scripts.Items.CollectableItems
{
    public class Shield : CollactableBase
    {
        [SerializeField] private GameObject playerHandPrefab;
        public override void TryCollect(CollectorBase _collector)
        {
            throw new System.NotImplementedException();
        }
    }
}