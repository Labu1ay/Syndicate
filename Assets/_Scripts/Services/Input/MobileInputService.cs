 using UnityEngine;

namespace _Scripts.Services.Input {
    public class MobileInputService : InputService {
        public override Vector2 Axis => SimpleInputAxis();
    }
}