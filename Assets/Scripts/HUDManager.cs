using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    [SerializeField]
    private Ship _playerShip;

    [SerializeField]
    private HealthComponent _playerHealth;

    [SerializeField]
    private Image _playerHealthBar;

    [SerializeField]
    private PowerComponent _playerPower;

    [SerializeField]
    private Image _playerPowerBar;

    private void Update()
    {
        _playerHealthBar.fillAmount = _playerHealth.Value / _playerShip.Life;
        _playerPowerBar.fillAmount = _playerPower.Value / _playerShip.Power;
    }
}