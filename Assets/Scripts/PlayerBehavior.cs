using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehavior : MonoBehaviour
{
    public float speed; //public means you can edit it in Unity Inspector

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    
    void Update()
    {
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
