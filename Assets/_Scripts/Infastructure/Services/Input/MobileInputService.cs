 using UnityEngine;

 namespace _Scripts.Infastructure.Services.Input {
    public class MobileInputService : InputService {
        public override Vector2 Axis => SimpleInputAxis();
    }
}