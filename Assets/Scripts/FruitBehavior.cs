using JetBrains.Annotations;
using UnityEngine;

public class FruitBehavior : MonoBehaviour
{
    public GameObject[] fruits;
    public int fruitType;
    private AudioSource mergeSource;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private bool hasMerged = false;
    void Start()
    {
        fruits = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehavior>().fruits;
        mergeSource = GameObject.FindGameObjectWithTag("Player").GetComponents<AudioSource>()[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasMerged) return;
        if (collision.gameObject.CompareTag("Fruit"))
        {
            
            GameObject otherFruit = collision.gameObject;
            int otherFruitType = otherFruit.GetComponent<FruitBehavior>().fruitType;

            if(fruitType == otherFruitType && (fruitType < fruits.Length - 1))
            {
                if(transform.position.x > otherFruit.transform.position.x || transform.position.y > otherFruit.transform.position.y && transform.position.x == otherFruit.transform.position.x)
                {
                   mergeSource.Play();
                   GameObject newFruit = Instantiate(fruits[fruitType + 1], Vector3.Lerp(transform.position,
                   otherFruit.transform.position, 0.5f), Quaternion.identity);
                   newFruit.GetComponent<Collider2D>().enabled = true;
                   newFruit.GetComponent<Rigidbody2D>().gravityScale = 1f;
                   GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehavior>().updateScore(fruitType);
                   //fixes fruit explosion
                   hasMerged = true;
                   collision.gameObject.GetComponent<FruitBehavior>().hasMerged = true;
                   Destroy(otherFruit);
                   Destroy(gameObject);
                }
               
            }
        }
    }
}
