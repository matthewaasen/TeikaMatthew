using UnityEngine;
using UnityEngine.UIElements;

public class BackgroundManager : MonoBehaviour
{
    public float speed;
    public GameObject bckPrefab;
    private GameObject[] bcks;
    public float pivotPoint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bcks = new GameObject[3];
        pivotPoint = - bckPrefab.transform.localScale.x * 0.32f * 16.0f;
        for(int i = 0; i < 3; i++)
        {
            float xPos = pivotPoint - (pivotPoint / 2 * i);
            float yPos = pivotPoint - (pivotPoint / 2 * i);
            Vector3 position = new Vector3(xPos, yPos, 0.0f);
            bcks[i] = Instantiate(bckPrefab, position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 3; i++)
        {
            float xPos = bcks[i].transform.position.x + (speed * Time.deltaTime);
            float yPos = bcks[i].transform.position.y + (speed * Time.deltaTime);
            Vector3 newPos = new Vector3(xPos, yPos, 0.0f);
            bcks[i].transform.position = newPos;
            if (xPos > -pivotPoint / 2)
            {
                Vector3 pivot = new Vector3(pivotPoint, pivotPoint, 0.0f);
                bcks[i].transform.position = pivot;
            }
        }
    }
}
