using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] TMP_Text enemiesLeftText;
    
    int enemiesLeft = 0;
    const string ENEMIES_LEFT_TEXT = "x ";

    public void AdjustEnemiesLeftText(int amount)
    {
        enemiesLeft += amount;
        enemiesLeftText.text = $"{ENEMIES_LEFT_TEXT}{enemiesLeft}";

        if (enemiesLeft <= 0)
        {
            AudioManager.Instance.PlayWin();
            MenuManager.Instance.TriggerVictory(); 
        }
    }
}