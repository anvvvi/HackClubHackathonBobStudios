using UnityEngine;
using UnityEngine.SceneManagement;
public class NextScene3 : MonoBehaviour
{   void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("HitFlag");
        SceneManager.LoadScene("");
    }
}