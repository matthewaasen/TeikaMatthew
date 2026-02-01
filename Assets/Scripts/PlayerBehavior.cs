using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehavior : MonoBehaviour
{
    public float speed; //public means you can edit it in Unity Inspector
    public GameObject fruit;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    
    void Update()
    {
        if (fruit != null)
        {
            Vector3 fruitOffset = new Vector3(0.0f, -1.0f, 0.0f);
            fruit.transform.position = gameObject.transform.position + fruitOffset; 
            fruit.GetComponent<Rigidbody2D>().gravityScale = 0.0f;
            fruit.GetComponent<Collider2D>().enabled = false;
        }

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            fruit.GetComponent<Rigidbody2D>().gravityScale = 1.0f;
            fruit.GetComponent<Collider2D>().enabled = true;
            fruit = null;
        }
        Keyboard kb = Keyboard.current;
        if (kb.leftArrowKey.isPressed || kb.aKey.isPressed)
        {
            Vector3 newPos = transform.position;
            newPos.x = newPos.x - speed;
            transform.position = newPos;
        }

        if (kb.rightArrowKey.isPressed || kb.dKey.isPressed)
        {
            Vector3 newPos = transform.position;
            newPos.x = newPos.x + speed;
            transform.position = newPos;
        }
    }
}
