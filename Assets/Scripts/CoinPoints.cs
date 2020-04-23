using UnityEngine;

public class CoinPoints : MonoBehaviour
{

    public int scoreIncrease;
    private ScoreCounter theScoreCounter;
    public AudioSource soundEffect;

    void Start()
    {
		scoreIncrease = 10;
        theScoreCounter = FindObjectOfType<ScoreCounter>();
        soundEffect = GameObject.Find("CoinSound").GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other)
	{
        if (other.gameObject.name == "Player")
		{
            theScoreCounter.AddScore(scoreIncrease);
            soundEffect.Play();
            gameObject.SetActive(false);
		}
	}

}
