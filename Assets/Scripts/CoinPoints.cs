using System.Collections;
using UnityEngine;

public class CoinPoints : MonoBehaviour
{

    public int scoreIncrease;
    private ScoreCounter theScoreCounter;
    // Start is called before the first frame update
    void Start()
    {
        theScoreCounter = FindObjectOfType<ScoreCounter>();
    }

    // Update is called once per frame
    void Update()
    {

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
