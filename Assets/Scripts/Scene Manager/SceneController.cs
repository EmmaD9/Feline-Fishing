using UnityEngine;
using UnityEngine.SceneManagement; 

public class SceneController : MonoBehaviour
{
    //loads tutorial
    public void LoadTutorial()
    {
        SceneManager.LoadScene("Instructions");
    }

    // loads game loop
    public void LoadMainGame()
    {
        SceneManager.LoadScene("MainGame");
    }

    //marketplace load in
    public void LoadMarketplace()
    {
        SceneManager.LoadScene("Market");
    }
}