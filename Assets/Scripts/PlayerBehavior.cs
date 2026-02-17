// cherry -> strawberry -> lemon  -> grape  -> orange -> apple -> pineapple -> pear -> banana -> watermelon
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehavior : MonoBehaviour
{
    public float speed; //public means you can edit it in Unity Inspector
    private GameObject currentFruit;

    public GameObject[] fruits;

    public double boundary = 2.18;

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
            int choice = Random.Range(0, 3);
            currentFruit = Instantiate(fruits[choice], transform.position, Quaternion.identity);
        }

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            currentFruit.GetComponent<Rigidbody2D>().gravityScale = 1.0f;
            currentFruit.GetComponent<Collider2D>().enabled = true;
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
}
