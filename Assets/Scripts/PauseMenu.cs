using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    private bool isPause;

    void Update()
	{
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPause)
			{
                ResumeGame();
            } else
			{
                PauseGame();
			}
        }

    }

    void PauseGame()
	{
        isPause = true;
        Time.timeScale = 0f;
        ScoreCounter.pause = true;
        pauseMenu.SetActive(true);
	}

    public void ResumeGame()
	{
        isPause = false;
        Time.timeScale = 1f;
        ScoreCounter.pause = false;
        pauseMenu.SetActive(false);
    }
}
