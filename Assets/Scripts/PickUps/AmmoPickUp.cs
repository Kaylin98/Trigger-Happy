using UnityEngine;

public class AmmoPickUp : PickUp
{
    [SerializeField] int ammoAmount = 100;

    protected override void OnPickUp(ActiveWeapon activeWeapon)
    {
        activeWeapon.AdjustAmmo(ammoAmount);
    }

}
