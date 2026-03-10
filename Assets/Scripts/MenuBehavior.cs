using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBehavior : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void goToGame()
    {
        SceneManager.LoadScene("TeikaGame");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
