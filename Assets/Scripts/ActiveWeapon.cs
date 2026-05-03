using StarterAssets;
using UnityEngine;

public class ActiveWeapon : MonoBehaviour
{
    [SerializeField] WeaponSO weaponSO;
    Animator animator;
    StarterAssetsInputs input;
    Weapon currentWeapon;

    float timeSinceLastShot = 0f;

    const string SHOOT_STRING = "Shoot";

    void Awake() 
    {
        input =  GetComponentInParent<StarterAssetsInputs>();
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        currentWeapon = GetComponentInChildren<Weapon>();
    }

    void Update()
    {
        timeSinceLastShot += Time.deltaTime;
        HandleShoot();
    }

    void HandleShoot()
    {
        if (!input.shoot) return;

        if (timeSinceLastShot < weaponSO.FireRate) return;

        currentWeapon.Shoot(weaponSO);
        animator.Play(SHOOT_STRING, 0, 0f);
        input.ShootInput(false);
        timeSinceLastShot = 0f;
    }
}
