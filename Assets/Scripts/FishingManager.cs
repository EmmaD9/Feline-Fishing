using NUnit.Framework;
using System.Collections;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

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

    [SerializeField]
    private float barMovement;
    [SerializeField]
    private float playerMovement;

    public static int fishHealth;

    public TextMeshProUGUI directions;
    public Slider fishHealthSlider;

    // Fish Scriptable objects
    public FishScriptableObject pinkFish;
    public FishScriptableObject minnow;
    public FishScriptableObject bluefinTuna;
    public FishScriptableObject sockeyeSalmon;
    public FishScriptableObject rainbowTrout;

    private FishScriptableObject currentFish;

    public Image fishImage;

    public Inventory inventory;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fishing = false;
        hooked = false;
        targetArea.transform.position = new Vector3(-4.22f, -0.08f, 0);
        fishingBar.transform.position = new Vector3(-4.22f, -0.29f, 0);
        playerArea.transform.position = new Vector3(-4.22f, -0.31f, 0);
        //barMovement = 0.005f;
        //playerMovement = 0.01f;
        fishHealthSlider.gameObject.SetActive(false);
        fishImage.gameObject.SetActive(false);
        directions.text = "Right Click to Cast";
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(fishHealth);
        if (Mouse.current.rightButton.wasPressedThisFrame && !fishing)
        {
            StartFishing();
            fishing = true;
        }
        if (hooked)
        {
            fishHealthSlider.value = fishHealth;
            if (fishHealth <= 0)
            {
                StartCoroutine(FishCaught());
            }
            if (currentTargetArea.transform.position.y >=2.6 || currentTargetArea.transform.position.y <=  -3.2)
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
                currentPlayerArea.transform.position -= new Vector3(0, (float)(playerMovement / 1.5), 0);
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
        int randomFish = Random.Range(1, 6);
        switch (randomFish)
        {
            case 1:
                currentFish = pinkFish;
                break;
            case 2:
                currentFish = minnow;
                break;
            case 3:
                currentFish = bluefinTuna;
                break;
            case 4:
                currentFish = sockeyeSalmon;
                break;
            case 5:
                currentFish = rainbowTrout;
                break;
        }
        directions.text = "Left Click to Reel";
        currentFishingBar = Instantiate(fishingBar);
        currentTargetArea = Instantiate(targetArea);
        currentPlayerArea = Instantiate(playerArea);
        fishHealth = (int)currentFish.Health;
        fishHealthSlider.value = fishHealth;
        fishHealthSlider.maxValue = fishHealth;
        fishHealthSlider.gameObject.SetActive(true);
        hooked = true;
    }
    private IEnumerator FishCaught()
    {
        directions.text = "You caught a " + currentFish.FishName + "!";
        inventory.fishCaught.Add(new FishClass(currentFish.FishName, currentFish.LengthMin, currentFish.LengthMax, currentFish.Texture, currentFish.SellPricePerLB));
        Debug.Log(inventory.fishCaught.Count);
        fishImage.gameObject.SetActive(true);
        fishImage.sprite = currentFish.Texture;
        Destroy(currentFishingBar);
        Destroy(currentTargetArea);
        Destroy(currentPlayerArea);
        fishHealthSlider.gameObject.SetActive(false);
        hooked = false;
        yield return new WaitForSeconds(3.0f);
        fishImage.gameObject.SetActive(false);
        fishImage.sprite = null;
        fishing = false;
        directions.text = "Right Click to Cast";
    }
}

