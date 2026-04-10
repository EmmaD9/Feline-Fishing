using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class FishingManager : MonoBehaviour
{

    private float timer;
    private bool fishing;
    private bool hooked;
    public GameObject fishingBar;
    public GameObject targetArea;
    public GameObject playerArea;

    private GameObject currentFishingBar;
    private GameObject currentTargetArea;
    private GameObject currentPlayerArea;

    private float barMovement;
    private float playerMovement;

    public static int fishHealth;

    public TextMeshProUGUI directions;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fishing = false;
        hooked = false;
        targetArea.transform.position = new Vector3(-4.22f, -0.08f, 0);
        fishingBar.transform.position = new Vector3(-4.22f, -0.29f, 0);
        playerArea.transform.position = new Vector3(-4.22f, -0.31f, 0);
        barMovement = 0.005f;
        playerMovement = 0.01f;
        fishHealth = 800;
        directions.text = "Right Click to Cast";
    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.rightButton.wasPressedThisFrame && !fishing)
        {
            StartFishing();
            fishing = true;
        }
        if (hooked)
        {
            if(fishHealth <= 0)
            {
                StartCoroutine(FishCaught());
            }
            if(currentTargetArea.transform.position.y >=2.6 || currentTargetArea.transform.position.y <=  -3.2)
            {
                barMovement *= -1;
            }
            currentTargetArea.transform.position += new Vector3(0, barMovement, 0);

            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                currentPlayerArea.transform.position += new Vector3(0, playerMovement * 100, 0);
                if(currentPlayerArea.transform.position.y >= 2.9)
                {
                    currentPlayerArea.transform.position = new Vector3(currentPlayerArea.transform.position.x, 2.9f, 0);
                }
            }
            else
            {
                currentPlayerArea.transform.position -= new Vector3(0, playerMovement, 0);
                if (currentPlayerArea.transform.position.y <= -3.4)
                {
                    currentPlayerArea.transform.position = new Vector3(currentPlayerArea.transform.position.x, -3.4f, 0);
                }
            }
        }
    }

    public void StartFishing()
    {
        directions.text = "Wait for it...";
        timer = Random.Range(2.0f, 10.0f);
        StartCoroutine(Timer(timer));
    }

    private IEnumerator Timer(float time)
    {
        yield return new WaitForSeconds(time);
        Debug.Log("Timer Finished");
        currentFishingBar = Instantiate(fishingBar);
        currentTargetArea = Instantiate(targetArea);
        currentPlayerArea = Instantiate(playerArea);
        hooked = true;
    }

    private IEnumerator FishCaught()
    {
        directions.text = "You caught one!";
        Destroy(currentFishingBar);
        Destroy(currentTargetArea);
        Destroy(currentPlayerArea);
        hooked = false;
        fishHealth = 800;
        yield return new WaitForSeconds(3.0f);
        fishing = false;
        directions.text = "Right Click to Cast";
    }
}
