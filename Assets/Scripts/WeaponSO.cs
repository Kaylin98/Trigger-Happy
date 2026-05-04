using UnityEngine;

[CreateAssetMenu(fileName = "WeaponSO", menuName = "Scriptable Objects/WeaponSO")]
public class WeaponSO : ScriptableObject
{
    public GameObject weaponPrefab;
    public int Damage = 1;
    public float FireRate = .5f;
    public int MaxAmmo = 30;
    public GameObject impactEffect;
    public bool IsAutomatic = false;
    public bool CanZoom = false;


}
