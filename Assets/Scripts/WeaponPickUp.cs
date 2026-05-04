using UnityEngine;

public class WeaponPickUp : MonoBehaviour
{
    [SerializeField] WeaponSO weaponSO;

    const string PLAYER_TAG = "Player";

    void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag(PLAYER_TAG))
        {
            ActiveWeapon activeWeapon = other.GetComponentInChildren<ActiveWeapon>();
            activeWeapon.SwitchWeapon(weaponSO);
            Destroy(gameObject);
        }
    }
}
