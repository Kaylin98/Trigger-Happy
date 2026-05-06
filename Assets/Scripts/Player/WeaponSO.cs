using UnityEngine;

[CreateAssetMenu(fileName = "WeaponSO", menuName = "Scriptable Objects/WeaponSO")]
public class WeaponSO : ScriptableObject
{
    public GameObject weaponPrefab;
    public int Damage = 1;
    public float FireRate = .5f;
    public GameObject impactEffect;
    public bool IsAutomatic = false;
    public bool CanZoom = false;
    public float ZoomFOV = 10f;
    public float ZoomSensitivityMultiplier = .4f;
    public int MagazineSize = 12;
}
