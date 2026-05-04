using StarterAssets;
using Unity.Cinemachine;
using UnityEngine;

public class ActiveWeapon : MonoBehaviour
{
    [SerializeField] WeaponSO weaponSO;
    [SerializeField] CinemachineVirtualCamera virtualCamera;
    [SerializeField] GameObject zoomReticle;
    Animator animator;
    StarterAssetsInputs input;
    Weapon currentWeapon;
    FirstPersonController firstPersonController;
    float defaultFOV;
    float defaultRotationSpeed;
    float timeSinceLastShot = 0f;

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
            zoomReticle.SetActive(true);
            virtualCamera.m_Lens.FieldOfView = weaponSO.ZoomFOV;
            firstPersonController.ChangeRotationSpeed(weaponSO.ZoomSensitivityMultiplier);
        }
        else
        {
            zoomReticle.SetActive(false);
            virtualCamera.m_Lens.FieldOfView = defaultFOV;
            firstPersonController.ChangeRotationSpeed(defaultRotationSpeed);
        }
    }
}
