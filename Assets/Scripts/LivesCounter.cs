using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LivesCounter : MonoBehaviour
{

	public static Text textBox;
	public static int lives;

	void Start()
	{
		textBox = GetComponent<Text>();
		lives = 3;
	}

    void Update()
    {
		if (lives == 0)
        {
			PlayerPrefs.SetString("score", ScoreCounter.score.ToString());
			SceneManager.LoadScene("GameOver");
		}
    }

    public static void UpdateLives()
	{
		lives--;
		textBox.text = "Lives: " + lives.ToString();
	}
}