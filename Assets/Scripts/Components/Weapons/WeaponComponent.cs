using UnityEngine;

public enum WeaponKind
{
    Player,
    Turret,
    EnemyShip
}

public class WeaponComponent : MonoBehaviour
{
    public GameObject BulletPrefab;
    public float FireSpeed;
    public float FireRate;
    public float BulletLifeTime;
    public float Range;
    public WeaponKind Kind;
}