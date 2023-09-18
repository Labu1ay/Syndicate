using UnityEngine;

namespace _Scripts.Infastructure.Services.Input {
    
    public abstract class InputService : IInputService {
        protected const string Horizontal = "Horizontal";
        protected const string Vertical = "Vertical"; 
        private const string Button = "Fire"; 
        
        public abstract Vector2 Axis { get; }

        public bool IsAttackButton() => SimpleInput.GetButtonUp(Button);

        protected static Vector2 SimpleInputAxis() => 
            new(SimpleInput.GetAxis(Horizontal), SimpleInput.GetAxis(Vertical));
    }
}