using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] TMP_Text enemiesLeftText;
    [SerializeField] TMP_Text winText;
    int enemiesLeft = 0;
    const string ENEMIES_LEFT_TEXT = "Enemies Left: ";

    public void AdjustEnemiesLeftText(int amount)
    {
        enemiesLeft += amount;
        enemiesLeftText.text = $"{ENEMIES_LEFT_TEXT}{enemiesLeft}";
        if (enemiesLeft <= 0)
        {
            winText.gameObject.SetActive(true);
        }
    }

    public void RestartGame()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
