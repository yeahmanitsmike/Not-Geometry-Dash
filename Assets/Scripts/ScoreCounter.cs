using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{

	public Text textBox;
	public static int score;
    public int iterations;

	void Start()
	{
		textBox = GetComponent<Text>();
		score = 0;
	}

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