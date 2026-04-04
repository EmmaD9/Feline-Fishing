using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class InventoryManager : MonoBehaviour
{
    private InventoryManager Instance;

    // Update from list of gameobjects to actual classes when mad.e
    [SerializeField]
    private List<GameObject> lures = new List<GameObject>();
    [SerializeField]
    private List<GameObject> rods = new List<GameObject>();
    private List<FishClass> fishCaught = new List<FishClass>();
    private float money;

    private GameObject currentLure;
    private GameObject currentRod;

    [SerializeField]
    private GameObject itemSelectDisplay;
    private List<GameObject> rodDisplays;

    [SerializeField]
    private GameObject itemButtonPrefab;

    [SerializeField]
    private Canvas theCanvas;


    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        money = 0;
        int numRodPanels = rods.Count / 8 + 1;
        rodDisplays = new List<GameObject>();

        for(int i = 0; i < numRodPanels; i++)
        {
            GameObject rodD = Instantiate(itemSelectDisplay);
            rodD.transform.parent = theCanvas.transform;
            rodDisplays.Add(rodD);
            rodD.transform.localPosition = new Vector3(477, -40, 0);

            for(int j = 0; j < 8; j++)
            {
                if (j < rods.Count)
                {
                    GameObject rodButton = Instantiate(itemButtonPrefab);
                    rodButton.transform.parent = rodD.transform;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SellFish()
    {
        foreach(FishClass fish in fishCaught)
        {
            money += fish.SellValue;
        }
        fishCaught.Clear();
    }

    public void SetActiveRod(GameObject rod)
    {
        currentRod = rod;
    }

    public void SetActiveLure(GameObject lure)
    {
        currentLure = lure;
    }
}
