using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LivesCounter : MonoBehaviour
{

	public static Text textBox;
	public static int lives;

	void Start()
	{
		textBox = GetComponent<Text>();
		lives = 3;
	}

    public static void UpdateLives()
	{
		lives--;
		textBox.text = "Lives: " + lives.ToString();
	}
}