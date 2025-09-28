using UnityEngine;

public class ExitButton : MonoBehaviour
{
    public void ExitGame()
    {
        // În editor nu se închide aplicația, dar va apărea în Build
        Application.Quit();

        // Doar pentru testare în Editor (NU se pune în build)
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}