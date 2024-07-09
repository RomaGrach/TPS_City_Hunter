using UnityEngine;

using LightDev;

namespace TPSShooter
{
  [RequireComponent(typeof(PlayerBehaviour))]
  public class PlayerAutoshoot : MonoBehaviour
  {
    public bool isEnabled = true;
    public bool useSavedData = true;

    private PlayerBehaviour player;

    private void Awake()
    {
      player = GetComponent<PlayerBehaviour>();
      if (useSavedData)
      {
        isEnabled = SaveLoad.IsAutoShoot;
      }
    }

    private void Update()
    {
      if (isEnabled && player && player.FireHitObject)
      {
        var enemy = player.FireHitObject.root.GetComponent<EnemyBehaviour>();
        if (enemy && enemy.IsAlive())
        {
          Events.FireRequested.Call();
        }
      }
    }
  }
}
