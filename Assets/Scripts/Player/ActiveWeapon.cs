using StarterAssets;
using TMPro;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.UI;

public class ActiveWeapon : MonoBehaviour
{
    [SerializeField] WeaponSO startingWeaponSO;
    [SerializeField] CinemachineVirtualCamera virtualCamera;
    [SerializeField] Camera weaponCamera;
    [SerializeField] Image crosshair;

    [SerializeField] GameObject zoomReticle;
    [SerializeField] TMP_Text ammoText;
    Animator animator;
    WeaponSO currentWeaponSO;
    StarterAssetsInputs input;
    public WeaponSO CurrentWeaponSO => currentWeaponSO;
    Weapon currentWeapon;
    FirstPersonController firstPersonController;
    float defaultFOV;
    float defaultRotationSpeed;
    float timeSinceLastShot = 0f;
    int currentAmmo;

    bool isZoomed = false;
    bool isMobile;

    const string SHOOT_STRING = "Shoot";

    void Awake() 
    {
        input =  GetComponentInParent<StarterAssetsInputs>();
        animator = GetComponent<Animator>();
        firstPersonController = GetComponentInParent<FirstPersonController>();
        defaultFOV = virtualCamera.m_Lens.FieldOfView;
        defaultRotationSpeed = firstPersonController.RotationSpeed;

        isMobile = Application.platform == RuntimePlatform.Android || 
               Application.platform == RuntimePlatform.IPhonePlayer;
    }
    void Start()
    {
        SwitchWeapon(startingWeaponSO, false);
        AdjustAmmo(currentWeaponSO.MagazineSize, false);
    }

    void Update()
    {
        HandleShoot();
        HandleZoom();
    }
    public void AdjustAmmo(int amount, bool playSound = true)
    {
        currentAmmo += amount;
        if(currentAmmo > currentWeaponSO.MagazineSize)
        {
            if (playSound) AudioManager.Instance.PlayAmmoPickup();
            currentAmmo = currentWeaponSO.MagazineSize;
        }
        else if (currentAmmo < 0)
        {
            currentAmmo = 0;
        }

        ammoText.text = currentAmmo.ToString("D2");
    }

    public void SwitchWeapon(WeaponSO weaponSO, bool playSound = true)
    {
        isZoomed = false;
        
        if(currentWeapon != null)
            Destroy(currentWeapon.gameObject);

        Weapon newWeapon = Instantiate(weaponSO.weaponPrefab, transform).GetComponent<Weapon>();
        if (playSound) AudioManager.Instance.PlayWeaponPickup();
        currentWeapon = newWeapon;
        this.currentWeaponSO = weaponSO;

        crosshair.sprite = weaponSO.crosshairSprite != null ? weaponSO.crosshairSprite : null;

        AdjustAmmo(weaponSO.MagazineSize, false);
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

        if (isMobile)
        {
            if (isZoomed) ZoomIn();
            else ZoomOut();
        }

        if (input.zoom) ZoomIn();
        else ZoomOut();
    }

    void ZoomIn()
    {
        SetCrosshair(currentWeaponSO.SniperZoomedCrosshairSprite, Vector3.one * 3f);
        zoomReticle.SetActive(true);
        virtualCamera.m_Lens.FieldOfView = currentWeaponSO.ZoomFOV;
        weaponCamera.fieldOfView = 0;
        firstPersonController.ChangeRotationSpeed(currentWeaponSO.ZoomSensitivityMultiplier);
    }

    void ZoomOut()
    {
        SetCrosshair(currentWeaponSO.crosshairSprite, Vector3.one);
        zoomReticle.SetActive(false);
        virtualCamera.m_Lens.FieldOfView = defaultFOV;
        weaponCamera.fieldOfView = defaultFOV;
        firstPersonController.ChangeRotationSpeed(defaultRotationSpeed);
    }

    public void MobileToggleZoom()
    {
        if (!currentWeaponSO.CanZoom) return;
        isZoomed = !isZoomed;
    }

    void SetCrosshair(Sprite sprite, Vector3 scale)
    {
        if (sprite == null) return;
        crosshair.sprite = sprite;
        crosshair.transform.localScale = scale;
        crosshair.enabled = true;
    }
}
