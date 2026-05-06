using StarterAssets;
using TMPro;
using Unity.Cinemachine;
using UnityEngine;

public class ActiveWeapon : MonoBehaviour
{
    [SerializeField] WeaponSO startingWeaponSO;
    [SerializeField] CinemachineVirtualCamera virtualCamera;
    [SerializeField] Camera weaponCamera;

    [SerializeField] GameObject zoomReticle;
    [SerializeField] TMP_Text ammoText;
    Animator animator;
    WeaponSO currentWeaponSO;
    StarterAssetsInputs input;
    Weapon currentWeapon;
    FirstPersonController firstPersonController;
    float defaultFOV;
    float defaultRotationSpeed;
    float timeSinceLastShot = 0f;
    int currentAmmo;

    const string SHOOT_STRING = "Shoot";

    void Awake() 
    {
        input =  GetComponentInParent<StarterAssetsInputs>();
        animator = GetComponent<Animator>();
        firstPersonController = GetComponentInParent<FirstPersonController>();
        defaultFOV = virtualCamera.m_Lens.FieldOfView;
        defaultRotationSpeed = firstPersonController.RotationSpeed;
    }
    void Start()
    {
        SwitchWeapon(startingWeaponSO);
        AdjustAmmo(currentWeaponSO.MagazineSize);
    }

    void Update()
    {
        HandleShoot();
        HandleZoom();
    }
    public void AdjustAmmo(int amount)
    {
        currentAmmo += amount;
        
        if(currentAmmo > currentWeaponSO.MagazineSize)
            currentAmmo = currentWeaponSO.MagazineSize;
        else if (currentAmmo < 0)
            currentAmmo = 0;

        ammoText.text = currentAmmo.ToString("D2");
    }

    public void SwitchWeapon(WeaponSO WeaponSO)
    {
        if(currentWeapon != null)
            Destroy(currentWeapon.gameObject);

        Weapon newWeapon = Instantiate(WeaponSO.weaponPrefab, transform).GetComponent<Weapon>();
        currentWeapon = newWeapon;
        this.currentWeaponSO = WeaponSO;

        AdjustAmmo(WeaponSO.MagazineSize);
    }

    void HandleShoot()
    {
        timeSinceLastShot += Time.deltaTime;

        if (!input.shoot) return;

        if (timeSinceLastShot >= currentWeaponSO.FireRate && currentAmmo > 0)
        {
            currentWeapon.Shoot(currentWeaponSO);
            animator.Play(SHOOT_STRING, 0, 0f);
            timeSinceLastShot = 0f;
            AdjustAmmo(-1);
        }

        
        
        if (!currentWeaponSO.IsAutomatic)
            input.ShootInput(false);
    }

    void HandleZoom()
    {
        if (!currentWeaponSO.CanZoom) return;

        if (input.zoom)
        {
            zoomReticle.SetActive(true);
            virtualCamera.m_Lens.FieldOfView = currentWeaponSO.ZoomFOV;
            weaponCamera.fieldOfView = 0;
            firstPersonController.ChangeRotationSpeed(currentWeaponSO.ZoomSensitivityMultiplier);
        }
        else
        {
            zoomReticle.SetActive(false);
            virtualCamera.m_Lens.FieldOfView = defaultFOV;
            weaponCamera.fieldOfView = defaultFOV;
            firstPersonController.ChangeRotationSpeed(defaultRotationSpeed);
        }
    }
}
