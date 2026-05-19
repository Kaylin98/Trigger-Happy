using UnityEngine;

public class MobileUIManager : MonoBehaviour
{
    [SerializeField] GameObject mobileControls;
    [SerializeField] UIVirtualButton zoomButton;
    [SerializeField] ActiveWeapon activeWeapon;

    void Awake()
    {
        // Hide on PC, show on mobile
        bool isMobile = Application.platform == RuntimePlatform.Android || 
                        Application.platform == RuntimePlatform.IPhonePlayer;
        
        mobileControls.SetActive(isMobile);
    }

    void Update()
    {
        if (!mobileControls.activeSelf) return;
        UpdateZoomButtonVisibility();
    }

    void UpdateZoomButtonVisibility()
    {
        bool canZoom = activeWeapon.CurrentWeaponSO != null && activeWeapon.CurrentWeaponSO.CanZoom;
        zoomButton.gameObject.SetActive(canZoom);
    }
}