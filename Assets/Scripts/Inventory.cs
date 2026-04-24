using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI.Table;

public class Inventory : MonoBehaviour
{

    public static Inventory Instance;

    [SerializeField]
    private List<RodScriptableObject> rods;
    private Dictionary<RodScriptableObject, bool> rodsBought = new Dictionary<RodScriptableObject, bool>();

    [SerializeField]
    private List<LureScriptableObject> lures;
    private Dictionary<LureScriptableObject, bool> luresBought = new Dictionary<LureScriptableObject, bool>();

    public List<FishClass> fishCaught = new List<FishClass>();

    private float money;

    public List<LureScriptableObject> Lures { get => lures; }
    public List<RodScriptableObject> Rods { get => rods; }
    public Dictionary<LureScriptableObject, bool> LuresBought { get => luresBought; set => luresBought = value; }
    public float Money { get => money; set => money = value; }
    public Dictionary<RodScriptableObject, bool> RodsBought { get => rodsBought; set => rodsBought = value; }
    public LureScriptableObject CurrentLure { get => currentLure; set => currentLure = value; }
    public RodScriptableObject CurrentRod { get => currentRod; set => currentRod = value; }

    // Selected lure and rod
    private LureScriptableObject currentLure;
    private RodScriptableObject currentRod;

    [SerializeField]
    private List<FishScriptableObject> possibleFish;
    private Dictionary<FishScriptableObject, FishClass> recordFish;
    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        for(int i = 0; i < rods.Count; i++)
        {
            rodsBought[rods[i]] = false;
        }
        rodsBought[rods[0]] = true;

        for (int i = 0; i < lures.Count; i++)
        {
            luresBought[lures[i]] = false;
        }
        luresBought[lures[0]] = true;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentLure = lures[0];
        currentRod = rods[0];
        for(int i = 0; i < possibleFish.Count; i++)
        {
            recordFish.Add(possibleFish[i], new FishClass(possibleFish[i].FishName, 0, 0, possibleFish[i].Texture, 0.0f));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SellFish()
    {
        foreach (FishClass fish in fishCaught)
        {
            money += fish.SellValue;
        }
        fishCaught.Clear();
    }

    public void SetActiveRod(RodScriptableObject rod)
    {
        if (rodsBought[rod])
        {
            currentRod = rod;
            Debug.Log("Current Rod: " + currentRod.RodName);
        }
    }

    public void SetActiveLure(LureScriptableObject lure)
    {
        if (luresBought[lure])
        {
            currentLure = lure;
            Debug.Log("Current Lure: " + currentLure.LureName);
        }
    }
}
