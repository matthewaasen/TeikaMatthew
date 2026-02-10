using UnityEngine;

public class TopBorderBehavior : MonoBehaviour
{
    public float timeout;
    private float timeStart;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        timeStart = Time.time;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (Time.time - timeStart > timeout)
        {
            print("Game Over");
        }
    }
}
