using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{

    public GameObject thePlatform;
    public GameObject endPlatform;
    private bool isEndPlatformSpawn;
    public Transform generationPoint;

    public float distanceBetween;
    private float platformWidth;

    public float distanceBetweenMin;
    public float distanceBetweenMax;

    //public GameObject[] thePlatforms;
    private int platformSelector;
    private float[] platformWidths;

    public float randomEnemyThreshold;
    public ObjectPooler enemyPool;

    private CoinGeneration myCoinGenerator;
    public float randomCoinThreshold;


    public ObjectPooler[] theObjectPools;
    private float minHeight;
    public float maxHeight;
    public float maxHeightChange;
    private float heightChange;
    public Transform maxHeightPoint;

    /*******************/
    /*LEVEL DESIGN VARS*/
    /*******************/
    private Queue levelSizeDesign;
    private Queue levelHeightDesign;
    private Queue levelDistanceDesign;
    //Platform Height is between 0 and 5 INTEGER
    public int[] level1_PlatformHeight;
    //Platform Size is either:
        //0 = 3 block platform, 1 = 5 block platform, 2 = 7 block platform, 3 = 9 block platform
    public int[] level1_PlatformSize;
    //Platform Distance is between 0 and Max Distance
    public int[] level1_PlatformDistance;
    private int distance;
    private int height;
    private int size;


    // Start is called before the first frame update
    void Start()
    {
        //Initializing Queues
        levelHeightDesign = new Queue();
        levelSizeDesign = new Queue();
        levelDistanceDesign = new Queue();

        //Loop that loads the Queue
        for (int i = 0; i < level1_PlatformHeight.Length; i++)
        {
            levelHeightDesign.Enqueue(level1_PlatformHeight[i]);
            levelSizeDesign.Enqueue(level1_PlatformSize[i]);
            levelDistanceDesign.Enqueue(level1_PlatformDistance[i]);
        }

        //platformWidth = thePlatform.GetComponent<BoxCollider2D>().size.x;

        platformWidths = new float[theObjectPools.Length];
        
        for(int i = 0; i < theObjectPools.Length; i++)
        {
            platformWidths[i] = theObjectPools[i].pooledObject.GetComponent<BoxCollider2D>().size.x;
        }

        minHeight = transform.position.y;
        maxHeight = maxHeightPoint.position.y;

        myCoinGenerator = FindObjectOfType<CoinGeneration>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (transform.position.x < generationPoint.position.x)
        {
            if (!(levelDistanceDesign.Count == 0 && levelHeightDesign.Count == 0 && levelSizeDesign.Count == 0))
            {
                size = (int)levelSizeDesign.Dequeue();
                height = (int)levelHeightDesign.Dequeue();
                distance = (int)levelDistanceDesign.Dequeue();

                /*THIS CODE WILL CHANGE IT TO A RANDOM LEVEL
                *distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);
                */
                if (distanceBetweenMin + distance > distanceBetweenMax)
                {
                    distanceBetween = distanceBetweenMax;
                }
                else
                {
                    distanceBetween = distanceBetweenMin + distance;
                }

                /*THIS CODE WILL CHANGE IT TO A RANDOM LEVEL
                *platformSelector = Random.Range(0, theObjectPools.Length);
                */

                if (size > 3)
                {
                    platformSelector = 3;
                }
                else if (size < 3)
                {
                    platformSelector = 0;
                }
                else
                {
                    platformSelector = size;
                }

                /*THIS CODE WILL CHANGE IT TO A RANDOM LEVEL
                *heightChange = transform.position.y + Random.Range(maxHeightChange, -maxHeightChange);
                */

                heightChange = minHeight + height;

                if (heightChange > maxHeight)
                {
                    heightChange = maxHeight;
                }
                else if (heightChange < minHeight)
                {
                    heightChange = minHeight;
                }

                transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2) + distanceBetween, heightChange, transform.position.z);

                //Instantiate(/*thePlatform*/ thePlatforms[platformSelector], transform.position, transform.rotation);
                GameObject newPlatform = theObjectPools[platformSelector].GetPooledObject();

                newPlatform.transform.position = transform.position;
                newPlatform.transform.rotation = transform.rotation;
                newPlatform.SetActive(true);


                float xpos = newPlatform.GetComponent<Transform>().position.x;
                float ypos = newPlatform.GetComponent<Transform>().position.y;
                float xoff = newPlatform.GetComponent<BoxCollider2D>().offset.x;
                float yoff = newPlatform.GetComponent<BoxCollider2D>().offset.y;

                if (Random.Range(0f, 100f) < randomCoinThreshold)
                {

                    if (newPlatform.GetComponent<BoxCollider2D>().size.x > 3.5)
                    {
                        myCoinGenerator.Spawn3Coins(new Vector3(xpos + xoff, ypos + yoff + 1f, transform.position.z));

                    }
                    else
                    {
                        myCoinGenerator.Spawn1Coins(new Vector3(xpos + xoff, ypos + yoff + 1f, transform.position.z));
                    }
                }

                if (Random.Range(0f, 100f) < randomEnemyThreshold && newPlatform.GetComponent<BoxCollider2D>().size.x > 3.5)
				{
                    GameObject newEnemy = enemyPool.GetPooledObject();
                    
                    float enemyXPos = Random.Range(-platformWidths[platformSelector] / 2 + 0.5f, platformWidths[platformSelector] / 2 - 0.5f);
                    
                    Vector3 enemyPosition = new Vector3(enemyXPos + xpos + xoff, ypos + yoff + 0.7f, 0f);

                    newEnemy.transform.position = enemyPosition;
                    newEnemy.transform.rotation = newEnemy.transform.rotation;
                    newEnemy.SetActive(true);
				}

                transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2), transform.position.y, transform.position.z);

            } else
			{
                if (!isEndPlatformSpawn)
				{
                    transform.position = new Vector3(transform.position.x + 6, transform.position.y, transform.position.z);
                    Instantiate(endPlatform, transform.position, transform.rotation);

                    isEndPlatformSpawn = true;
                }

            }
        }
       

    }
}
