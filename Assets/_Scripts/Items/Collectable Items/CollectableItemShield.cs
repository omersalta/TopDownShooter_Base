using _Scripts.Player;
using UnityEngine;

namespace _Scripts.Items.CollectableItems
{
    public class CollectableItemShield : CollactableItemBase
    {
        [SerializeField] private GameObject playerHandPrefab;
        public override void TryCollect(PlayerItemCollector playerItemCollector)
        {
            throw new System.NotImplementedException();
        }
    }
}