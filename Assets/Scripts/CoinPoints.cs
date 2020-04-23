using UnityEngine;

public class CoinPoints : MonoBehaviour
{

    public int scoreIncrease;
    private ScoreCounter theScoreCounter;

    void Start()
    {
        theScoreCounter = FindObjectOfType<ScoreCounter>();
    }

    void OnTriggerEnter2D(Collider2D other)
	{
        if (other.gameObject.name == "Player")
		{
            theScoreCounter.AddScore(scoreIncrease);
            gameObject.SetActive(false);
		}
	}

}
