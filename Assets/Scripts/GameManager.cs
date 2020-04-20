using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerController thePlayer;
    private Vector3 PlayerStartPoint;
    public AudioSource backgroundMusic;

    void Start()
    {
        PlayerStartPoint = thePlayer.transform.position;
    }

    public void Restart()
    {
        StartCoroutine("RestartCo");
        ScoreCounter.score = 0;
    }

    public IEnumerator RestartCo()
    {

        thePlayer.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);

        thePlayer.transform.position = PlayerStartPoint;
        thePlayer.gameObject.SetActive(true);
        backgroundMusic.Play();

    }
}