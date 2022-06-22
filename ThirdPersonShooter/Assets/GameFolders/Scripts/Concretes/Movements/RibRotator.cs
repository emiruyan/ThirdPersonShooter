using ThirdPersonShooter.Abstracts.Movements;
using UnityEngine;

namespace ThirdPersonShooter.Movements
{
    public class RibRotator : IRotator
    { 
        Transform _transform;
        float _tilt;

        public RibRotator(Transform transform)
        {
            _transform = transform;
        }
        
        public void RotationAction(float direction, float speed)
        {
            direction *= speed * Time.deltaTime;
            _tilt = Mathf.Clamp(_tilt - direction, -30f, 30f);  
            
            _transform.Rotate(new Vector3(0f,0f, _tilt));
        }
    }
}