using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    private InventoryManager Instance;

    // Update from list of gameobjects to actual classes when mad.e
    [SerializeField]
    private List<GameObject> lures = new List<GameObject>();
    private List<GameObject> bait = new List<GameObject>();
    private List<Fish> fishCaught = new List<Fish>();
    private float money;


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
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SellFish()
    {
        foreach(Fish fish in fishCaught)
        {
            money += fish.SellValue;
        }
        fishCaught.Clear();
    }
}
