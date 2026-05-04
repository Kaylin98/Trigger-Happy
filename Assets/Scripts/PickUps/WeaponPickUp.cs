using UnityEngine;

public class WeaponPickUp : PickUp
{
    [SerializeField] WeaponSO weaponSO;

    protected override void OnPickUp(ActiveWeapon activeWeapon)
    {
        activeWeapon.SwitchWeapon(weaponSO);
    }
    
}
