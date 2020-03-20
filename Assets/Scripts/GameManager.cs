using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerController thePlayer;

    void Start()
    {
        // PlayerStartPoint = thePlayer.transform.position;
    }

    public void Restart()
    {
        StartCoroutine("RestartCo");
    }

    public IEnumerator RestartCo()
    {
        thePlayer.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);

        thePlayer.gameObject.SetActive(true);
    }
}