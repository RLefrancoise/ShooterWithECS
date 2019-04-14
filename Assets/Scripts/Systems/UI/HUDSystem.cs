using Components;
using Unity.Entities;

namespace Systems.UI
{
    public class HUDSystem : ComponentSystem
    {
        /// <inheritdoc />
        protected override void OnUpdate()
        {
            /*Entities.ForEach((HUD hud) =>
            {
                hud.playerHealthBar.fillAmount = hud.playerHealth.Value / hud.playerShip.Life;
                hud.playerPowerBar.fillAmount = hud.playerPower.Value / hud.playerShip.Power;
            });*/
        }
    }
}