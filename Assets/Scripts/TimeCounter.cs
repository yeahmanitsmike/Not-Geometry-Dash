using UnityEngine;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour
{

	public Text textBox;
	public static int time;
    public int iterations;
	public static bool pause;

	void Start()
	{
		textBox = GetComponent<Text>();
		time = 0;
	}

	void Update()
	{
		if (!pause)
		{
			iterations++;
			if (iterations > 60)
			{
				time++;
				iterations = 0;
			}
			textBox.text = "Time: " + time.ToString();
		}
	}

}