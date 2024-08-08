using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TPSShooter
{
    public class gunHandSet : MonoBehaviour
    {
        public WeaponPickUp WeaponPickUp = null;
        public PlayerWeapon PlayerWeapon = null;
        public bool ak = false;
    // Start is called before the first frame update

        // Update is called once per frame
        void Update()
        {
            if(WeaponPickUp.parentBone == null)
            {
                GameObject player = GameObject.FindGameObjectWithTag("Player");
                WeaponPickUp.parentBone = player.GetComponent<playergunpossitions>().parentBonePB;

                if (ak)
                {
                    PlayerWeapon.ScopeSettings.CameraPosition = player.GetComponent<playergunpossitions>().CameraPositionAK;
                    PlayerWeapon.ScopeSettings.WeaponParent = player.GetComponent<playergunpossitions>().WeaponParentAK;
                    PlayerWeapon.ScopeSettings.WeaponLocalPositionRotation = player.GetComponent<playergunpossitions>().WeaponLocalPositionRotationAK;
                }
            }

            
        }
    }
}