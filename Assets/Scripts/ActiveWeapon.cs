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
        HandleShoot();
        HandleZoom();
    }

    public void SwitchWeapon(WeaponSO WeaponSO)
    {
        if(currentWeapon != null)
            Destroy(currentWeapon.gameObject);

        Weapon newWeapon = Instantiate(WeaponSO.weaponPrefab, transform).GetComponent<Weapon>();
        currentWeapon = newWeapon;
        this.weaponSO = WeaponSO;
    }

    void HandleShoot()
    {
        timeSinceLastShot += Time.deltaTime;

        if (!input.shoot) return;

        if (timeSinceLastShot < weaponSO.FireRate) return;

        currentWeapon.Shoot(weaponSO);
        animator.Play(SHOOT_STRING, 0, 0f);
        timeSinceLastShot = 0f;
        
        if (!weaponSO.IsAutomatic)
            input.ShootInput(false);
    }

    void HandleZoom()
    {
        if (!weaponSO.CanZoom) return;

        if (input.zoom)
        {
                Debug.Log("Zooming in...");
                // Implement zoom functionality here
        }
        else
        {
                Debug.Log("Zooming out...");
                // Implement unzoom functionality here
        }
    }
}
