using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerController thePlayer;
    private Vector3 PlayerStartPoint;
    public AudioSource backgroundMusic;

    private Vector3 platformStartPoint;
    public Transform platformGenerator;

    private PlatformDestroyer[] platformList;

    void Start()
    {
        platformStartPoint = platformGenerator.position;
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
        yield return new WaitForSeconds(1.0f);

        platformList = FindObjectsOfType<PlatformDestroyer>();
        for(int i = 0; i < platformList.Length; i++)
        {
            platformList[i].gameObject.SetActive(false);
        }

        thePlayer.transform.position = PlayerStartPoint;
        platformGenerator.position = platformStartPoint;
        thePlayer.gameObject.SetActive(true);
        backgroundMusic.Play();

    }
}