using UnityEngine;
using TMPro;

public class TopBorderBehavior : MonoBehaviour
{
    public float timeout;
    private float timeStart;
    public TMP_Text gameOverText;
    public GameObject gameOverPanel;
    public GameObject[] walls;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameOverText.gameObject.SetActive(false);
        gameOverPanel.SetActive(false);
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
            gameOverText.gameObject.SetActive(true);
            gameOverPanel.SetActive(true);
            for(int i = 0; i < walls.Length; i++)
            {
                GameObject wall = walls[i];
                Rigidbody2D rb = wall.GetComponent<Rigidbody2D>();
                rb.bodyType = RigidbodyType2D.Dynamic;  


            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        timeStart = 0.0f;
    }
}
