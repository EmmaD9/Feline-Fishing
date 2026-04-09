using UnityEngine;

public class QuitGame : MonoBehaviour
{
    public void ExitGame()
    {
        // This logs a message to the console to confirm it works
        Debug.Log("Game is exiting...");

        // This quits the actual application
        Application.Quit();
    }
}
