using UnityEngine;
using UnityEngine.SceneManagement;
public class PassFinalSacrifice : MonoBehaviour
{
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Level3");
        }
        else if (!Input.GetKey(KeyCode.Space))
        {
            Application.Quit();
        }
    }
}
