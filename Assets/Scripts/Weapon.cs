using StarterAssets;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] WeaponSO weaponSO;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] ParticleSystem impactEffect;
    [SerializeField] Animator animator;
    StarterAssetsInputs input;
    const string SHOOT_STRING = "Shoot";

    void Awake() 
    {
        input =  GetComponentInParent<StarterAssetsInputs>();
    }

    void Update()
    {
        HandleShoot();
    }

    void HandleShoot()
    {
        if (!input.shoot) return;

        muzzleFlash.Play();
        animator.Play(SHOOT_STRING, 0, 0f);
        input.ShootInput(false);

        RaycastHit hit;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity))
        {
            Instantiate(impactEffect, hit.point, Quaternion.identity);
            EnemyHealth enemyHealth = hit.collider.GetComponent<EnemyHealth>();
            enemyHealth?.TakeDamage(weaponSO.Damage);
        }

    }
}
