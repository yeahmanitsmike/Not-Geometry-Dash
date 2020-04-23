using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    private bool isPause;
    public AudioSource backgroundMusic;

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
        TimeCounter.pause = true;
        pauseMenu.SetActive(true);
        backgroundMusic.Pause();
	}

    public void ResumeGame()
	{
        isPause = false;
        Time.timeScale = 1f;
        TimeCounter.pause = false;
        pauseMenu.SetActive(false);
        backgroundMusic.Play();
    }
}
