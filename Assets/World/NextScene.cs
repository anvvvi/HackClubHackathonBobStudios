using UnityEngine;
using UnityEngine.SceneManagement;
public class NextScene : MonoBehaviour
{ 
    void OnTriggerEnter2D(Collider2D other)
    {
        SceneManager.LoadScene("1StSacrificeScreen");
    }
}
