using UnityEngine;

namespace _Scripts.Infastructure.Services.Input {
    public interface IInputService : IService{
        Vector2 Axis { get; }
        bool IsAttackButton();
    }
}