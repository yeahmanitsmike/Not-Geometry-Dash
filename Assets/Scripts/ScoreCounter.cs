using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{

	public Text textBox;
	public static int score;

	void Start()
	{
		textBox = GetComponent<Text>();
		score = 0;
	}

    private void Update()
    {
		textBox.text = "Score: " + score.ToString();
	}

    public void AddScore(int pointsToAdd)
	{
		score += pointsToAdd;
	}
}