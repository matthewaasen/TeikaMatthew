using JetBrains.Annotations;
using UnityEngine;

public class FruitBehavior : MonoBehaviour
{
    public GameObject[] fruits;
    public int fruitType;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fruits = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehavior>().fruits;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Fruit"))
        {
            GameObject otherFruit = collision.gameObject;
            int otherFruitType = otherFruit.GetComponent<FruitBehavior>().fruitType;

            if(fruitType == otherFruitType && fruitType != 10)
            {
                if(transform.position.x > otherFruit.transform.position.x || transform.position.y > otherFruit.transform.position.y && transform.position.x == otherFruit.transform.position.x)
                {
                   GameObject newFruit = Instantiate(fruits[fruitType + 1], Vector3.Lerp(transform.position,
                   otherFruit.transform.position, 0.5f), Quaternion.identity);
                   newFruit.GetComponent<Collider2D>().enabled = true;
                   newFruit.GetComponent<Rigidbody2D>().gravityScale = 1f;
                   Destroy(otherFruit);
                   Destroy(gameObject);
                }
               
            }
        }
    }
}
