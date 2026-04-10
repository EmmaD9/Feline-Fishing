using NUnit.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using static UnityEngine.Rendering.DebugUI.Table;
using UnityEngine.UI;

public class MarketManager : MonoBehaviour
{
    public static MarketManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BuyRod(RodScriptableObject rod)
    {
        if (rod.Cost <= Inventory.Instance.Money && Inventory.Instance.RodsBought[rod] == false)
        {
            Inventory.Instance.RodsBought[rod] = true;
            Debug.Log("Bought: " + rod.RodName);
            Inventory.Instance.Money -= rod.Cost;
            EventSystem.current.currentSelectedGameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Sold Out";
        }
    }

    public void BuyLure(LureScriptableObject lure)
    {
        if (lure.Cost <= Inventory.Instance.Money && Inventory.Instance.LuresBought[lure] == false)
        {
            Inventory.Instance.LuresBought[lure] = true;
            Debug.Log("Bought: " + lure.LureName);
            Inventory.Instance.Money -= lure.Cost;
            EventSystem.current.currentSelectedGameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Sold Out";
        }
    }

    public void ReturnToSea()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void SellFish()
    {
        Inventory.Instance.SellFish();
    }
}
