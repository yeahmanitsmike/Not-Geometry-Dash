using UnityEngine;

public class LevelPartGenerator : MonoBehaviour
{

    public GameObject levelPart;
    public Transform generationPoint;

    private float levelPartWidth;

    void Start()
    {
        levelPartWidth = levelPart.GetComponent<BoxCollider2D>().size.x;
    }

    void Update()
    {
        if (transform.position.x < generationPoint.position.x)
        {
            transform.position = new Vector3(transform.position.x + levelPartWidth, transform.position.y, transform.position.z);

            Instantiate(levelPart, transform.position, transform.rotation);
        }
    }
}
