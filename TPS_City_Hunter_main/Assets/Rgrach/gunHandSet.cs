using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TPSShooter
{
    public class gunHandSet : MonoBehaviour
    {
        public WeaponPickUp WeaponPickUp = null;
    // Start is called before the first frame update
        void Start()
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            WeaponPickUp.parentBone = player.GetComponent<PlayerBehaviour>().parentBonePB;
        }

        // Update is called once per frame
        void Update()
        {
            if(WeaponPickUp.parentBone == null)
            {
                GameObject player = GameObject.FindGameObjectWithTag("Player");
                WeaponPickUp.parentBone = player.GetComponent<PlayerBehaviour>().parentBonePB;
            }
        }
    }
}