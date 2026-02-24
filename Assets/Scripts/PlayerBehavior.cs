// cherry 0 -> strawberry 10   -> lemon 30 -> grape 70 -> orange 130 -> apple 210 -> pineapple 310 -> pear 430 -> banana 570 -> watermelon
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
public class PlayerBehavior : MonoBehaviour
{
    public float speed; //public means you can edit it in Unity Inspector
    private GameObject currentFruit;

    public GameObject[] fruits;

    public double boundary = 2.18;

    public int[] points;
    public int total = 0;
    public TMP_Text scoreText;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    
    void Update()
    {
        if (currentFruit != null)
        {
            Vector3 fruitOffset = new Vector3(0.0f, -1.0f, 0.0f);
            currentFruit.transform.position = gameObject.transform.position + fruitOffset; 
            currentFruit.GetComponent<Rigidbody2D>().gravityScale = 0.0f;
        }
        else
        {
            int choice = 0;
            //makes big fruit for debugging purposes
            if (Keyboard.current.wKey.isPressed)
            {
                 choice = 8;
            }
            else
            {
                 choice = GameObject.FindGameObjectWithTag("Queue").GetComponent<QueueController>().updateQueue();

            }
                currentFruit = Instantiate(fruits[choice], transform.position, Quaternion.identity);
        }

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            currentFruit.GetComponent<Rigidbody2D>().gravityScale = 1.0f;
            currentFruit.GetComponent<Collider2D>().enabled = true;
            GetComponents<AudioSource>()[1].Play();
            currentFruit = null;
        }
        Keyboard kb = Keyboard.current;
        if (kb.leftArrowKey.isPressed || kb.aKey.isPressed)
        {
            Vector3 newPos = transform.position;
            if(newPos.x >= -boundary)
            {
                newPos.x = newPos.x - speed;
                transform.position = newPos;
            }
            
        }
        
        if (kb.rightArrowKey.isPressed || kb.dKey.isPressed)
        {
            Vector3 newPos = transform.position;
            if(newPos.x <= boundary)
            {
                newPos.x = newPos.x + speed;
                transform.position = newPos;
            }
        }
    }

    public void updateScore(int index)
    {
        total += points[index];
        scoreText.SetText("Score: " + total);
    }
    
}
