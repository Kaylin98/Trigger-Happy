using UnityEngine;
using CandyCoded.HapticFeedback; 

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
        HapticFeedback.MediumFeedback(); 
    }

    public void VibrateOnPress(bool isPressed)
    {
        if (isPressed)
        {
            HapticFeedback.MediumFeedback();
        }
    }
}