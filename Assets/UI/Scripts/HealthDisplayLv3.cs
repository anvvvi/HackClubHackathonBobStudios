using UnityEngine;
using TMPro; // Only if using TextMeshPro
// using UnityEngine.UI; // Use this if using regular UI Text

public class HealthDisplayLv3 : MonoBehaviour
{
    public PlayerMovementLv3 player;  // Assign in Inspector
    public TMP_Text healthText;    // Or Text if using regular UI Text

    void Update()
    {
        healthText.text = "Health: " + player.Health;
    }
}