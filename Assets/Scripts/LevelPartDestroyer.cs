using UnityEngine;

public class LevelPartDestroyer : MonoBehaviour
{
    private GameObject levelPartDestroyerPoint;

    void Start()
    {
        levelPartDestroyerPoint = GameObject.Find("LevelPartDestroyerPoint");
    }

    void Update()
    {
        if (transform.position.x < levelPartDestroyerPoint.transform.position.x)
        {
            Destroy(gameObject);
        }
    }
}
