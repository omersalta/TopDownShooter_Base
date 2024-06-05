using System;
using _Scripts.Extensions;
using _Scripts.ShootMechanic.Health_System._Base;
using ToolBox.Pools;
using UnityEngine;

namespace _Scripts.Inventory_Items
{
    public abstract class ProjectileBase : MonoBehaviour
    {
        protected projectileData data;
        protected float _totalTime = 0f;
        protected float _currentTime;
        protected float _multiplayer;
        
        public virtual void Setup(projectileData data)
        {
            transform.forward = data.ShootDirection;
            this.data = data;
            _totalTime = this.data.MaxRange / data.averageVelocity;
            Mathf.Clamp(this.data.Integrate, 0.05f, 1f);
            _multiplayer = 1 / data.Integrate;
            _currentTime = 0;
        }


    }
}