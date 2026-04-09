using UnityEngine;

public class QuitGame : MonoBehaviour
{
    public void ExitGame()
    {
        // log to confirm it works
        Debug.Log("Game is exiting...");

        // close application
        Application.Quit();

        //testing to see if it works in editor
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
