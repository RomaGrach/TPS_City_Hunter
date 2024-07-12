using UnityEngine;

using LightDev;
using LightDev.UI;

namespace TPSShooter.UI.Menu
{
  public class Menu : CanvasElement
  {
    [Header("References")]
    public ButtonScale playButton;
    public ButtonScale settingsButton;
    public ButtonScale exitButton;

    public override void Subscribe()
    {
      Events.SceneLoaded += Show;
      Events.RequestMenu += Show;
    }

    public override void Unsubscribe()
    {
      Events.SceneLoaded -= Show;
      Events.RequestMenu -= Show;
    }

    protected override void OnStartShowing()
    {
      playButton.AnimateScaleShow();
      settingsButton.AnimateScaleShow(0.15f);
      exitButton.AnimateScaleShow(0.3f);
    }

    public void OnPlay()
    {
      Events.MenuClickSound.Call();
      Events.RequestMenuWeapon.Call();
      Hide();
    }

    public void OnSettings()
    {
      Events.MenuClickSound.Call();
      Events.RequestMenuSettings.Call();
      Hide();
    }

    public void OnExit()
    {
      Application.Quit();
    }
  }
}
