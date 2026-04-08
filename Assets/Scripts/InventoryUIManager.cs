using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class InventoryUIManager : MonoBehaviour
{
    // Update from list of gameobjects to actual classes when made

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

    // Nav buttons for inventory
    [SerializeField]
    private Button leftNavButton, rightNavButton, rodListButton, lureListButton;

    // References to all buttons made.
    private List<Button> rodButtons =  new List<Button> ();
    private List<Button> lureButtons = new List<Button>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        rods = Inventory.Instance.Rods;
        lures = Inventory.Instance.Lures;

        // Set current money
        SetUpInventoryUI();
    }

    // Update is called once per frame
    void Update()
    {
        
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
        if (rods.Count % 8 == 0)
        {
            numRodPanels = rods.Count / 8;
        }
        else
        {
            numRodPanels = rods.Count / 8 + 1;
        }

            rodDisplays = new List<GameObject>();

        // For each rod panel
        for (int i = 0; i < numRodPanels; i++)
        {
            // Create display and set transform
            GameObject rodD = Instantiate(itemSelectDisplay);
            rodD.transform.parent = theCanvas.transform;
            rodDisplays.Add(rodD);
            rodD.transform.localPosition = new Vector3(477, -40, 0);

            // Add buttons
            for (int j = 0; j < 8; j++)
            {
                if (j < tempRods.Count)
                {
                    GameObject rodButton = Instantiate(itemButtonPrefab);
                    rodButton.transform.parent = rodD.transform;
                    rodButtons.Add(rodButton.GetComponent<Button>());
                }
            }

            // Remove buttons from temp
            for (int j = 0; j < 8; j++)
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
        if (rods.Count % 8 == 0)
        {
            numLurePanels = lures.Count / 8;
        }
        else
        {
            numLurePanels = lures.Count / 8 + 1;
        }
        lureDisplays = new List<GameObject>();

        // For each display
        for (int i = 0; i < numLurePanels; i++)
        {
            // Create display & set transform
            GameObject lureD = Instantiate(itemSelectDisplay);
            lureD.transform.parent = theCanvas.transform;
            lureDisplays.Add(lureD);
            lureD.transform.localPosition = new Vector3(477, -40, 0);


            // Set buttons up to max capacity
            for (int j = 0; j < 8; j++)
            {
                if (j < tempLures.Count)
                {
                    GameObject lureButton = Instantiate(itemButtonPrefab);
                    lureButton.transform.parent = lureD.transform;
                    lureButtons.Add(lureButton.GetComponent<Button>());
                }
            }

            // Remove temp references.
            for (int j = 0; j < 8; j++)
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

        for (int i = 0; i < rodButtons.Count; i++)
        {
            RodScriptableObject myRod = rods[i];
            rodButtons[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = rods[i].RodName;
            rodButtons[i].onClick.AddListener(() => Inventory.Instance.SetActiveRod(myRod));
        }
        for (int i = 0; i < lureButtons.Count; i++)
        {
            LureScriptableObject myLure = lures[i];
            lureButtons[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = lures[i].LureName;
            lureButtons[i].onClick.AddListener(() => Inventory.Instance.SetActiveLure(myLure));
        }
    }
}
