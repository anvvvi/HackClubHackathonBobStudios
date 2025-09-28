using UnityEngine;
using UnityEngine.SceneManagement;
public class NextScene2 : MonoBehaviour
{   void OnTriggerEnter2D(Collider2D other)
    {
        SceneManager.LoadScene("2ndSacrificeScreen");
    }
}