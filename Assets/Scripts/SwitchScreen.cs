using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScreen : MonoBehaviour
{
    public void StartGame() {
        SceneManager.LoadScene("Level");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Level");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
