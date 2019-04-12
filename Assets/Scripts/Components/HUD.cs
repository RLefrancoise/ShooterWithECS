using UnityEngine;
using UnityEngine.UI;

namespace Components
{
    public class HUD : MonoBehaviour
    {
        public Ship playerShip;
        public HealthComponent playerHealth;
        public PowerComponent playerPower;
        public Image playerHealthBar;
        public Image playerPowerBar;
    }
}