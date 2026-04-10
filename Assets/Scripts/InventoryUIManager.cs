using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InventoryUIManager : MonoBehaviour
{

    public delegate void LureBehavior();
    public LureBehavior lureBehavior;
    public delegate void RodBehavior();

    // Lists of items to be in inventory
    private List<LureScriptableObject> lures = new List<LureScriptableObject>();
    private List<RodScriptableObject> rods = new List<RodScriptableObject>();
    private List<FishClass> fishCaught = new List<FishClass>();


    // Panel displays for lures and rod + prefab to make panels
    [SerializeField]
    private GameObject itemSelectDisplay;
    private List<GameObject> rodDisplays;
    private List<GameObject> lureDisplays;
    private List<GameObject> activeDisplayCategory;
    private GameObject lastRodDisplay;
    private GameObject lastLureDisplay;
    private GameObject lastDisplay;

    // Button to represent an option to select an item
    [SerializeField]
    private GameObject itemButtonPrefab;

    
    [SerializeField]
    private Canvas theCanvas;

    // References to all buttons made.
    private List<Button> rodButtons =  new List<Button>();
    private List<Button> lureButtons = new List<Button>();

    [SerializeField]
    private TextMeshProUGUI moneyText;

    [SerializeField]
    private Vector3 panelPosition;

    [SerializeField]
    private int btnsPerPanel;

    [SerializeField]
    private bool isMarket;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        rods = Inventory.Instance.Rods;
        lures = Inventory.Instance.Lures;
        // Set current money
        SetUpInventoryUI();
        if (isMarket)
        {
            SetUpButtonBehaviorMarket();
        }
        else
        {
            SetUpButtonBehaviorInventory();
        }
    }

    public void OnEnable()
    {
        if (isMarket)
        {
            SetUpButtonBehaviorMarket();
        }
        else
        {
            SetUpButtonBehaviorInventory();
        }
    }

    // Update is called once per frame
    void Update()
    {
        moneyText.text = "Money: $" + Inventory.Instance.Money;
    }

    public void NavLeftInventory()
    {
        if(activeDisplayCategory == rodDisplays)
        {
            int index = rodDisplays.IndexOf(lastRodDisplay);
            if (index > 0)
            {
                lastRodDisplay.SetActive(false);
                lastRodDisplay = rodDisplays[index - 1];
                lastRodDisplay.SetActive(true);
                lastDisplay = lastRodDisplay;
            }
        }
        else if (activeDisplayCategory == lureDisplays)
        {
            int index = lureDisplays.IndexOf(lastLureDisplay);
            if (index > 0)
            {
                lastLureDisplay.SetActive(false);
                lastLureDisplay = lureDisplays[index - 1];
                lastLureDisplay.SetActive(true);
                lastDisplay = lastLureDisplay;
            }
        }
    }

    public void NavRightInventory()
    {
        if (activeDisplayCategory == rodDisplays)
        {
            int index = rodDisplays.IndexOf(lastRodDisplay);
            if (index < rodDisplays.Count-1)
            {
                lastRodDisplay.SetActive(false);
                lastRodDisplay = rodDisplays[index + 1];
                lastRodDisplay.SetActive(true);
                lastDisplay = lastRodDisplay;
            }
        }
        else if (activeDisplayCategory == lureDisplays)
        {
            int index = lureDisplays.IndexOf(lastLureDisplay);
            if (index < lureDisplays.Count - 1)
            {
                lastLureDisplay.SetActive(false);
                lastLureDisplay = lureDisplays[index + 1];
                lastLureDisplay.SetActive(true);
                lastDisplay = lastLureDisplay;
            }
        }
    }

    public void OpenRods()
    {
        activeDisplayCategory = rodDisplays;
        lastDisplay.SetActive(false);
        lastRodDisplay.SetActive(true);
        lastDisplay = lastRodDisplay;
    }

    public void OpenLures()
    {
        activeDisplayCategory = lureDisplays;
        lastDisplay.SetActive(false);
        lastLureDisplay.SetActive(true);
        lastDisplay=lastLureDisplay;
    }

    public void SetUpInventoryUI()
    {
        // Temp reference to rods
        List<RodScriptableObject> tempRods = new List<RodScriptableObject>(rods);

        int numRodPanels = 0;
        // Calculate # of panels needed.
        if (rods.Count % btnsPerPanel == 0)
        {
            numRodPanels = rods.Count / btnsPerPanel;
        }
        else
        {
            numRodPanels = rods.Count / btnsPerPanel + 1;
        }

            rodDisplays = new List<GameObject>();

        // For each rod panel
        for (int i = 0; i < numRodPanels; i++)
        {
            // Create display and set transform
            GameObject rodD = Instantiate(itemSelectDisplay);
            rodD.transform.parent = theCanvas.transform;
            rodDisplays.Add(rodD);
            rodD.transform.localPosition = panelPosition;

            // Add buttons
            for (int j = 0; j < btnsPerPanel; j++)
            {
                if (j < tempRods.Count)
                {
                    GameObject rodButton = Instantiate(itemButtonPrefab);
                    rodButton.transform.parent = rodD.transform;
                    rodButtons.Add(rodButton.GetComponent<Button>());
                }
            }

            // Remove buttons from temp
            for (int j = 0; j < btnsPerPanel; j++)
            {
                if (j < tempRods.Count)
                {
                    tempRods.Remove(tempRods[0]);
                }
            }
        }

        // Temp reference to lures
        List<LureScriptableObject> tempLures = new List<LureScriptableObject>(lures);

        // Calculate # of panels for lures
        int numLurePanels = 0;
        // Calculate # of panels needed.
        if (lures.Count % btnsPerPanel == 0)
        {
            numLurePanels = lures.Count / btnsPerPanel;
        }
        else
        {
            numLurePanels = lures.Count / btnsPerPanel + 1;
        }
        lureDisplays = new List<GameObject>();

        // For each display
        for (int i = 0; i < numLurePanels; i++)
        {
            // Create display & set transform
            GameObject lureD = Instantiate(itemSelectDisplay);
            lureD.transform.parent = theCanvas.transform;
            lureDisplays.Add(lureD);
            lureD.transform.localPosition = panelPosition;


            // Set buttons up to max capacity
            for (int j = 0; j < btnsPerPanel; j++)
            {
                if (j < tempLures.Count - 1)
                {
                    GameObject lureButton = Instantiate(itemButtonPrefab);
                    lureButton.transform.parent = lureD.transform;
                    lureButtons.Add(lureButton.GetComponent<Button>());
                }
            }

            // Remove temp references.
            for (int j = 0; j < btnsPerPanel; j++)
            {
                if (j < tempLures.Count)
                {
                    tempLures.Remove(tempLures[0]);
                }
            }
        }

        foreach (GameObject display in rodDisplays)
        {
            display.gameObject.SetActive(false);
        }
        foreach (GameObject display in lureDisplays)
        {
            display.gameObject.SetActive(false);
        }
        rodDisplays[0].SetActive(true);
        activeDisplayCategory = rodDisplays;
        lastDisplay = rodDisplays[0];
        lastRodDisplay = rodDisplays[0];
        lastLureDisplay = lureDisplays[0];
    }

    public void SetUpButtonBehaviorMarket()
    {
        for (int i = 0; i < rodButtons.Count; i++)
        {
            RodScriptableObject myRod = rods[i];
            if (Inventory.Instance.RodsBought[myRod] == false)
            {
                GameObject price = new GameObject();
                price.transform.parent = rodButtons[i].gameObject.transform;
                price.transform.localPosition = new Vector3(50, -100, 0);
                price.AddComponent<TextMeshProUGUI>();
                TextMeshProUGUI text = price.GetComponent<TextMeshProUGUI>();
                text.text = "Price: " + rods[i].Cost;
                Instantiate(price);
                rodButtons[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = myRod.RodName;
                rodButtons[i].onClick.AddListener(() => MarketManager.Instance.BuyRod(myRod));
            }
            else
            {
                rodButtons[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Sold Out";
            }
            
        }
        for (int i = 0; i < lureButtons.Count; i++)
        {
            LureScriptableObject myLure = lures[i];
            if (Inventory.Instance.LuresBought[myLure] == false)
            {
                GameObject price = new GameObject();
                price.transform.parent = lureButtons[i].gameObject.transform;
                price.transform.localPosition = new Vector3(50, -100, 0);
                price.AddComponent<TextMeshProUGUI>();
                TextMeshProUGUI text = price.GetComponent<TextMeshProUGUI>();
                text.text = "Price: " + lures[i].Cost;
                
                Instantiate(price);
                lureButtons[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = myLure.LureName;
                lureButtons[i].onClick.AddListener(() => MarketManager.Instance.BuyLure(myLure));
            }
            else
            {
                lureButtons[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Sold Out";
            }
            
        }
    }
    public void SetUpButtonBehaviorInventory()
    {
        for (int i = 0; i < rodButtons.Count; i++)
        {
            RodScriptableObject myRod = Inventory.Instance.Rods[i];
            if (Inventory.Instance.RodsBought[myRod] == true)
            {
                rodButtons[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = myRod.RodName;
            }
            else
            {
                rodButtons[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Not Owned";
            }
            rodButtons[i].onClick.AddListener(()=>Inventory.Instance.SetActiveRod(myRod));

        }
        for (int i = 0; i < lureButtons.Count; i++)
        {
            LureScriptableObject myLure = Inventory.Instance.Lures[i];
            if(Inventory.Instance.LuresBought[myLure] == true)
            {
                lureButtons[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = myLure.LureName;
            }
            else
            {
                lureButtons[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Not Owned";
            }
            lureButtons[i].onClick.AddListener(() => Inventory.Instance.SetActiveLure(myLure));
        }
    }

    public void ReturnToOcean()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void GoToMarket()
    {
        SceneManager.LoadScene("Market");
    }
}
