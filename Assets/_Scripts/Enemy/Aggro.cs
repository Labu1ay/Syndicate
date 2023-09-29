using System.Collections;
using UnityEngine;

namespace _Scripts.Enemy {
    public class Aggro : MonoBehaviour {
        public TriggerObserver TriggerObserver;
        public Follow Follow;

        public float Cooldawn;
        private Coroutine _aggroCoroutine;
        private bool _hasAggroTarget;

        private void Start() {
            TriggerObserver.TriggerEnter += TriggerEnter;
            TriggerObserver.TriggerExit += TriggerExit;

            SwitchFollowOff();
        }

        private void TriggerEnter(Collider obj) {
            if (!_hasAggroTarget) {
                _hasAggroTarget = true;
                StopAggroCoroutine();
                SwitchFollowOn();
            }
            
        }

        private void TriggerExit(Collider obj) {
            if (_hasAggroTarget) {
                _hasAggroTarget = false;
                _aggroCoroutine = StartCoroutine(SwitchFollowOffAfterCooldawn());
            }
            
        }

        private void StopAggroCoroutine() {
            if (_aggroCoroutine != null) {
                StopCoroutine(_aggroCoroutine);
                _aggroCoroutine = null;
            }
        }

        private IEnumerator SwitchFollowOffAfterCooldawn() {
            yield return new WaitForSeconds(Cooldawn);
            SwitchFollowOff();
        }

        private void SwitchFollowOn() => Follow.enabled = true;

        private void SwitchFollowOff() => Follow.enabled = false;
    }
}