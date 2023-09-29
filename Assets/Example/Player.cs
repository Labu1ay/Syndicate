using System;
using UnityEngine;

namespace Example {
    public class Player : MonoBehaviour {
        public float Health { get; private set; } = 5;
        //public event Action CreateBonus;
        
        public void ApplyDamage(float value) {
            Health -= value;
            if (Health < 3) {
                Messenger.Broadcast("Bonus", new Bundle().Set("int", 16));
                Messenger.Broadcast("Bonus2", new Bundle().Set("int", 16).Set("int", false));
                //CreateBonus?.Invoke();
            }
        }
    }
}