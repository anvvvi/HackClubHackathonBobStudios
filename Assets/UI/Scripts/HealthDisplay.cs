using UnityEngine;
using TMPro; // Only if using TextMeshPro
// using UnityEngine.UI; // Use this if using regular UI Text

public class HealthDisplay : MonoBehaviour
{
    public PlayerMovement player;  // Assign in Inspector
    public TMP_Text healthText;    // Or Text if using regular UI Text

    void Update()
    {
        healthText.text = "Health: " + player.Health;
    }
}