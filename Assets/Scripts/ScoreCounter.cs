using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{

	public Text textBox;
	public static int score;
    public int iterations;
	public static bool pause;

	void Start()
	{
		textBox = GetComponent<Text>();
		score = 0;
	}

	void Update()
	{
		if (!pause)
		{
			iterations++;
			if (iterations > 60)
			{
				score++;
				iterations = 0;
			}
			textBox.text = "Score: " + score.ToString();
		}
	}

    public void AddScore(int pointsToAdd)
	{
		score += pointsToAdd;
	}
}