using UnityEngine;

public class CoinPoints : MonoBehaviour
{

    public int scoreIncrease;
    private ScoreCounter scoreCounter;
    public AudioSource soundEffect;

    void Start()
    {
        scoreCounter = FindObjectOfType<ScoreCounter>();
        soundEffect = GameObject.Find("CoinSound").GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other)
	{
        if (other.gameObject.name == "Player")
		{
            scoreCounter.AddScore(scoreIncrease);
            soundEffect.Play();
            gameObject.SetActive(false);
		}
	}

}
