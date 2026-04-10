using TMPro;
using UnityEngine;

public class EquipmentDisplayTemp : MonoBehaviour

{
    [SerializeField]
    private TextMeshProUGUI tempRodDisplay, tempLureDisplay;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        tempLureDisplay.text = "Lure: " + Inventory.Instance.CurrentLure.LureName;
        tempRodDisplay.text = "Lure: " + Inventory.Instance.CurrentRod.RodName;
    }
}
