using UnityEngine;
using UnityEngine.SceneManagement;
using StarterAssets;
using UnityEngine.InputSystem;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance; 

    [Header("Menu Containers")]
    [SerializeField] GameObject gameplayHUD;
    [SerializeField] GameObject gameOverContainer;
    [SerializeField] GameObject victoryContainer;
    [SerializeField] GameObject pauseContainer;

    private bool isPaused = false;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        ResumeGame(); 
    }

    void Update()
    {
        if (Keyboard.current != null && Keyboard.current.pKey.wasPressedThisFrame)
        {
            if (!gameOverContainer.activeSelf && !victoryContainer.activeSelf)
            {
                TogglePause();
            }
        }
    }
    // --- PAUSE LOGIC ---
    public void TogglePause()
    {
        if (isPaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        isPaused = true;
        gameplayHUD.SetActive(false);
        pauseContainer.SetActive(true);
        Time.timeScale = 0f; // Freeze game
        SetCursorState(false); // Unlock the mouse so you can click buttons
    }

    public void ResumeGame()
    {
        isPaused = false;
        pauseContainer.SetActive(false);
        gameOverContainer.SetActive(false);
        victoryContainer.SetActive(false);
        
        gameplayHUD.SetActive(true);
        Time.timeScale = 1f; // Unfreeze game
        SetCursorState(true); // Lock the mouse back to the center for aiming
    }

    // --- GAME STATE LOGIC ---
    public void TriggerGameOver()
    {
        gameplayHUD.SetActive(false);
        gameOverContainer.SetActive(true);
        SetCursorState(false); // Unlock mouse
    }

    public void TriggerVictory()
    {
        gameplayHUD.SetActive(false);
        victoryContainer.SetActive(true);
        SetCursorState(false); // Unlock mouse
        Time.timeScale = 0.1f;
    }

    // --- CURSOR CONTROL ---
    private void SetCursorState(bool isLocked)
    {
        StarterAssetsInputs playerInput = FindFirstObjectByType<StarterAssetsInputs>();
        if (playerInput != null)
        {
            playerInput.SetCursorState(isLocked);
        }
    }

    // --- BUTTON ACTIONS ---
    public void RestartLevel()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }
}