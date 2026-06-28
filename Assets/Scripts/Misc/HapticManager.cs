using UnityEngine;
#if UNITY_ANDROID || UNITY_IOS
using CandyCoded.HapticFeedback;
#endif

public class HapticManager : MonoBehaviour
{
    public static HapticManager Instance;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void Vibrate()
    {
#if UNITY_ANDROID || UNITY_IOS
        HapticFeedback.MediumFeedback();
#endif
    }

    public void VibrateOnPress(bool isPressed)
    {
        #if UNITY_ANDROID || UNITY_IOS
        if (isPressed)
        {
            HapticFeedback.MediumFeedback();
        }
#endif
        
    }
}