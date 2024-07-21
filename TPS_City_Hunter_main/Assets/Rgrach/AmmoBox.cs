using System.Collections;
using UnityEngine;
using LightDev;

namespace TPSShooter
{
    public class AmmoBox : MonoBehaviour
    {
        private bool playerInRange = false;
        private PlayerWeapon currentWeapon;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                playerInRange = true;
                PlayerBehaviour playerBehaviour = other.GetComponent<PlayerBehaviour>();
                if (playerBehaviour != null)
                {
                    currentWeapon = playerBehaviour.weaponSettings.CurrentWeapon;
                    StartCoroutine(RefillAmmo());
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                playerInRange = false;
                StopCoroutine(RefillAmmo());
            }
        }

        private IEnumerator RefillAmmo()
        {
            while (playerInRange)
            {
                if (currentWeapon != null && currentWeapon.BulletsAmount < 200)
                {
                    currentWeapon.BulletsAmount += currentWeapon.MagCapacity;
                    Events.PlayerAmmoRefilled.Call(); // Вызов события для обновления UI
                    yield return new WaitForSeconds(3f);
                }
                else
                {
                    yield return null;
                }
            }
        }
    }
}