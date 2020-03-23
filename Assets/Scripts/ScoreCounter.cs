using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{

	public Text textBox;
	public static int score;
    public int iterations;

	// Start is called before the first frame update
	void Start()
	{
		textBox = GetComponent<Text>();
		score = 0;
	}

	// Update is called once per frame
	void Update()
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