using UnityEngine;

namespace ThirdPersonShooter.Abstracts.Inputs
{
    public interface IInputReader
    {
        Vector3 Direction { get; }
    }
}