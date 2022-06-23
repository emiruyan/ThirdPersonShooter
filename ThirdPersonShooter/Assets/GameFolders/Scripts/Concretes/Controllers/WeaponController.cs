
using ThirdPersonShooter.Abstracts.Combats;
using ThirdPersonShooter.ScriptableObjects;
using UnityEngine;

namespace ThirdPersonShooter.Controllers
{
    public class WeaponController : MonoBehaviour
    {
        [SerializeField] bool _canFire;
       
        //public GameObject _crossHair;
        
        float _currentTime = 0f;
        IAttackType _attackType;
        public AnimatorOverrideController AnimatorOverride => _attackType.AttackInfo.AnimatorOverride;   

        private void Awake()
        {
            _attackType = GetComponent<IAttackType>();
        }

        private void Update()
        { 
            _currentTime += Time.deltaTime;

            _canFire = _currentTime > _attackType.AttackInfo.AttackMaxDelay;
        }

        public void Attack()
        {
            if (!_canFire) return;

            _attackType.AttackAction(); 

            _currentTime = 0f;
        }
    }
}



