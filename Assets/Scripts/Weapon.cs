using Unity.Cinemachine;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] LayerMask interactionLayers;
    CinemachineImpulseSource impulseSource;
    const string SHOOT_STRING = "Shoot";

    void Awake()
    {
        impulseSource = GetComponent<CinemachineImpulseSource>();
    }

    public void Shoot(WeaponSO weaponSO)
    {
        muzzleFlash.Play();
        RaycastHit hit;
        impulseSource.GenerateImpulse();


        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity, interactionLayers, QueryTriggerInteraction.Ignore))
        {
            Instantiate(weaponSO.impactEffect, hit.point, Quaternion.identity);
            EnemyHealth enemyHealth = hit.collider.GetComponent<EnemyHealth>();
            enemyHealth?.TakeDamage(weaponSO.Damage);
        }

    }
}
