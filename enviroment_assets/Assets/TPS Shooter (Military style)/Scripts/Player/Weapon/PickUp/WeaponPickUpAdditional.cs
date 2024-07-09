using UnityEngine;

namespace TPSShooter
{

    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(WeaponPickUp))]
    public class WeaponPickUpAdditional : MonoBehaviour
    {

        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();

            WeaponPickUp weaponPick = GetComponent<WeaponPickUp>();
            weaponPick.OnWeaponPickedUpEvent += OnWeaponPickedUp;
            weaponPick.OnWeaponDroppedEvent += OnWeaponDropped;
        }

        private void OnWeaponPickedUp()
        {
            _animator.enabled = false;
            transform.localScale = Vector3.one;
        }

        private void OnWeaponDropped()
        {
            _animator.enabled = true;
            transform.localScale = new Vector3(2, 2,2);
        }

    }

}