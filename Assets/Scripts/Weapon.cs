using StarterAssets;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    StarterAssetsInputs input;
    int damageAmount = 1;

    void Awake() 
    {
        input =  GetComponentInParent<StarterAssetsInputs>();
    }

    void Update()
    {
         HandleShoot();
    }

    bool HandleShoot()
    {
        if (!input.shoot) return false;

        RaycastHit hit;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity))
        {
            EnemyHealth enemyHealth = hit.collider.GetComponent<EnemyHealth>();
            enemyHealth?.TakeDamage(damageAmount);

            input.ShootInput(false);
        }

        return true;
    }
}
