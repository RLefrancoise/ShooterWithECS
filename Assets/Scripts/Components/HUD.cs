using UnityEngine;
using UnityEngine.UI;

namespace Components
{
    public class HUD : MonoBehaviour
    {
        public Ship playerShip;
        public Health playerHealth;
        public Power playerPower;
        public Image playerHealthBar;
        public Image playerPowerBar;
    }
}