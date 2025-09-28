using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class IntroStory : MonoBehaviour
{ 
    public TMP_Text text;
    private int spacePressed = 0;
    void Update()
    {
        if (spacePressed == 0)
        {
            text.text = "Long ago, the world was broken by greed and pride.";
            spacePressed = 1;
        }

        if (Input.anyKeyDown && spacePressed == 1)
        {
            spacePressed = 2;
            text.text = "Only those willing to sacrifice can restore balance.";
        }
        else if (Input.anyKeyDown && spacePressed == 2)
        {
            spacePressed = 3;
            text.text = "Each choice takes away a power… yet opens a path forward.";
        }
        else if (Input.anyKeyDown && spacePressed == 3)
        {
            spacePressed = 4;
            text.text = "Your journey begins now.";
        }

        if (spacePressed == 4 && Input.anyKeyDown)
        {
            SceneManager.LoadScene("Level1");
        }
    }
}
