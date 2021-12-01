using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Play Button - Loads the Game Scene
    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }
    
    // Close Game
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Closed!!");
    }
}
