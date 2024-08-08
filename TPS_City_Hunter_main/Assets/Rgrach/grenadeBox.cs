using UnityEngine;
using UnityEngine.UI;
using LightDev;

namespace TPSShooter
{
    public class grenadeBox : MonoBehaviour
    {
        private bool playerInRange = false;
        private PlayerWeapon currentWeapon;
        public float refillCooldown = 3f; // Время в секундах для пополнения патронов
        private float refillTimer;
        PlayerBehaviour PlayerBehaviour1;

        [SerializeField] private Image refillImage; // Ссылка на UI-элемент картинки

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                playerInRange = true;
                PlayerBehaviour playerBehaviour = other.GetComponent<PlayerBehaviour>();
                PlayerBehaviour1 = playerBehaviour;
                if (playerBehaviour != null)
                {
                    currentWeapon = playerBehaviour.weaponSettings.CurrentWeapon;
                    refillTimer = 0f; // Сбросить таймер
                    UpdateRefillImageVisibility(); // Обновить видимость картинки
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                playerInRange = false;
                refillImage.gameObject.SetActive(false); // Скрыть картинку
            }
        }

        private void Update()
        {
            if (playerInRange && currentWeapon != null)
            {
                if (currentWeapon.BulletsAmount < 200)
                {
                    refillTimer += Time.deltaTime;
                    refillImage.fillAmount = Mathf.Clamp01(refillTimer / refillCooldown); // Обновить заполнение картинки

                    if (refillTimer >= refillCooldown)
                    {
                        PlayerBehaviour1.grenadeSettings.GrenadeAmo += 1;
                        currentWeapon.BulletsAmount += currentWeapon.MagCapacity;
                        Events.PlayerAmmoRefilled.Call(); // Вызов события для обновления UI
                        refillTimer = 0f; // Сбросить таймер после пополнения
                    }
                }
                else
                {
                    refillImage.gameObject.SetActive(false); // Скрыть картинку, если патроны полные
                }
            }
            else if (refillImage.gameObject.activeSelf)
            {
                refillImage.fillAmount = 0; // Сбросить заполнение картинки
            }
        }

        private void UpdateRefillImageVisibility()
        {
            if (currentWeapon != null && currentWeapon.BulletsAmount < 200)
            {
                refillImage.gameObject.SetActive(true); // Показать картинку
            }
            else
            {
                refillImage.gameObject.SetActive(false); // Скрыть картинку
            }
        }
    }
}
