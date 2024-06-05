using System;
using _Scripts.Extensions;
using _Scripts.Player;

namespace _Scripts.UI
{
    public class PlayerHealthBar : HealthBar
    {

        public override void Start()
        {
            myCharacter.OnChange.AddListener(CheckIsDead);
            base.Start();
        }
        public override void Update()
        {
            
        }

        private void CheckIsDead()
        {
            if (myCharacter.Health() <= 0)
            {
                FindObjectOfType<UIManager>().Set(null);
                FindObjectOfType<PlayerInventory>().DropAll();
                FindObjectOfType<PlayerInput>().isActive = false;
                Utils.Wait(this,3, () =>
                {
                    FindObjectOfType<PlayerInput>().isActive = true;
                });
                
            }
        }
        
        
    }
}