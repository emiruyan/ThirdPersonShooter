using UnityEngine;

namespace ThirdPersonShooter.Abstracts.Inputs
{
    public interface IInputReader
    {
        Vector3 Direction { get; }
        Vector2 Rotation { get; } 
        bool IsAttackButtonPress { get; }
        bool IsInventoryButtonPressed { get; }
    }
}