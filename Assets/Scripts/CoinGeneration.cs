using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGeneration : MonoBehaviour
{
    // Start is called before the first frame update

    public ObjectPooler coinPool;

    public float distBetwCoins;
    // Start is called before the first frame update

    public void Spawn3Coins(Vector3 startPos)
    {
        GameObject Coin1 = coinPool.GetPooledObject();
        Coin1.transform.position = startPos;
        Coin1.SetActive(true);

        GameObject Coin2 = coinPool.GetPooledObject();
        Coin2.transform.position = new Vector3(startPos.x - distBetwCoins, startPos.y, startPos.z);
        Coin2.SetActive(true);

        GameObject Coin3 = coinPool.GetPooledObject();
        Coin3.transform.position = new Vector3(startPos.x + distBetwCoins, startPos.y, startPos.z);
        Coin3.SetActive(true);

    }

    public void Spawn1Coins(Vector3 starPosition)
	{
        GameObject coinOne = coinPool.GetPooledObject();
        coinOne.transform.position = starPosition;
        coinOne.SetActive(true);
    }
}
