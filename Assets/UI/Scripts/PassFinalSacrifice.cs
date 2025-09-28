using UnityEngine;
using UnityEngine.SceneManagement;
public class PassFinalSacrifice : MonoBehaviour
{
    
     public float timeLimit = 5f; // seconds to wait
    private float timer;

    void Update()
    {
        if (Input.anyKeyDown)
        {
            if (!Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Wrong key pressed, quitting.");
                Application.Quit();
            }
            else
            {
                Debug.Log("Space pressed, continue game.");
                SceneManager.LoadScene("Level3");
            }
        }
    }    
}
