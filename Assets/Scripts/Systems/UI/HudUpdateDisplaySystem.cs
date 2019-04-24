using Components;
using Components.UI;
using Unity.Entities;

namespace Systems.UI
{
    /// <summary>
    /// Update HUD display system
    /// </summary>
    public class HudUpdateDisplaySystem : ComponentSystem
    {
        protected override void OnUpdate()
        {
            Entities.ForEach((HUD hud, ref HudData data) =>
            {
                hud.playerHealthBar.fillAmount = data.health;
                hud.playerPowerBar.fillAmount = data.power;
            });
        }
    }
}