using UnityEngine;

namespace _Scripts.Hero {
    public class HeroAnimator : MonoBehaviour {
        private static readonly int MoveHash = Animator.StringToHash("Walking");
        public Animator Animator;
        public CharacterController CharacterController;

        private void Update() {
            Animator.SetFloat(MoveHash, CharacterController.velocity.magnitude, 0.1f, Time.deltaTime);
        }
    }
}