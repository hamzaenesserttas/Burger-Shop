using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{

    [SerializeField] private GameObject pauseMenuUI;

    [SerializeField] private bool isPaused = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void OnEscapeMenu(InputValue Button) 
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

    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false); // Menü kapat
        Time.timeScale = 1f; // Oyunu devam ettir
        isPaused = false;
    }

    public void PauseGame()
    {
        Debug.Log("durdu");
        pauseMenuUI.SetActive(true); // Menü aç
        Time.timeScale = 0f; // Oyunu durdur
        isPaused = true;
    }

    public void OnClickResume()
    {
        ResumeGame();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
