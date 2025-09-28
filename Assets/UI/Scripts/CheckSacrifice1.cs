using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class CheckSacrifice1 : MonoBehaviour
{
    public static bool sprintSacrifice = false;
    public static bool jumpSacrifice = false;
    public TMP_Text sacrificeText;

    private bool sacrificeChosen;
    // Update is called once per frame
    void Update()
    {
        if (sacrificeChosen) SceneManager.LoadScene("2ndLevel"); // stop code after choice

        if (sprintSacrifice == jumpSacrifice)
        {
            sacrificeText.text =
                "Finished Level 1\n\nYou now must make a sacrifice\n\nPress Space to lose Double Jump and double your sprint\n\nPress Shift to lose Sprint and gain an extra jump";
            Debug.Log("Finished Level 1");
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            sprintSacrifice = true;
            sacrificeText.text = "";
            sacrificeChosen = true;
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpSacrifice = true;
            sacrificeText.text = "";
            sacrificeChosen = true;
        }
    }
}
