using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LivesCounter : MonoBehaviour
{

	public static Text textBox;
	public static int lives;
	private string currentSceneName;

	void Start()
	{
		textBox = GetComponent<Text>();
		currentSceneName = SceneManager.GetActiveScene().name;
        if (currentSceneName == "Level1") lives = 3;
        else if (currentSceneName == "Level2") lives = 4;
		else if (currentSceneName == "Level3") lives = 5;
	}

    void Update()
    {
		if (lives == 0)
        {
			SceneManager.LoadScene("GameOver");
		}
    }

    public static void UpdateLives()
	{
		lives--;
		textBox.text = "Lives: " + lives.ToString();
	}
}