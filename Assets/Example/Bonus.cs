using System;
using UnityEngine;

namespace Example {
    public class Bonus : MonoBehaviour {
        

        private void Start() {
            Messenger.AddListener("Bonus", CreateBonus);
            Messenger.AddListener("Bonus2", CreateBonus2);
        }

        private void CreateBonus(Bundle bundle) => Debug.Log("Bonus created - " + bundle.Get<int>("int"));
        private void CreateBonus2(Bundle bundle) => Debug.Log("Bonus created - " + bundle.Get<int>("int") +" "+bundle.Get<bool>("int"));

        private void OnDestroy() {
            Messenger.RemoveListener("Bonus", CreateBonus);
            Messenger.RemoveListener("Bonus2", CreateBonus2);
        }
    }
}