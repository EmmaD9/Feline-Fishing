using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState { MainMenu, Roaming, Fishing, Minigame, Market }

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState currentState;

    [Header("Session Data")]
    public FishClass currentActiveFish; // The fish currently on the hook

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Call this to change states and handle logic
    public void ChangeState(GameState newState)
    {
        currentState = newState;

        switch (currentState)
        {
            case GameState.Fishing:
                // Logic for preparing the water
                break;
            case GameState.Minigame:
                // Logic for UI popping up
                break;
            case GameState.Market:
                SceneManager.LoadScene("Market");
                break;
        }
    }

    // This bridges your FishingManager and your Inventory
    public void CatchFish(FishClass caughtFish)
    {
        Inventory.Instance.Money += caughtFish.SellValue; // Or add to a list
        Debug.Log($"You caught a {caughtFish.Name} worth ${caughtFish.SellValue}!");
        ChangeState(GameState.Roaming);
    }
}