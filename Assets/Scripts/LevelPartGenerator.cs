using UnityEngine;

public class LevelPartGenerator : MonoBehaviour
{
    public GameObject[] levelParts;
    public Transform generationPoint;
    
    private float levelPartsWidth = 10f;
    private int levelPartSelector;

    void Update()
    {
        if (transform.position.x < generationPoint.position.x)
        {

            levelPartSelector = Random.Range(0, levelParts.Length);

            transform.position = new Vector3(transform.position.x + levelPartsWidth, transform.position.y, transform.position.z);

            Instantiate(levelParts[levelPartSelector], transform.position, transform.rotation);
        }
    }
}
