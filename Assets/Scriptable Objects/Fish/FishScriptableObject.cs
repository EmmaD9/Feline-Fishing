using UnityEngine;

[CreateAssetMenu(fileName = "FishScriptableObject", menuName = "Scriptable Objects/FishScriptableObject")]
public class FishScriptableObject : ScriptableObject
{
    [SerializeField]
    private string fishName;
    [SerializeField]
    private float lengthMin, lengthMax;
    private float length;
    [SerializeField]
    private float weight;
    [SerializeField]
    private float health;
    [SerializeField]
    private float sellPricePerLB;

    private float sellValue;

    public string FishName { get => fishName; set => fishName = value; }
    public float Length { get => length; set => length = value; }
    public float Weight { get => weight; set => weight = value; }
    public float Health { get => health; set => health = value; }
    public float SellPricePerLB { get => sellPricePerLB; set => sellPricePerLB = value; }
    public float SellValue { get => sellValue; set => sellValue = value; }


    private void Awake()
    {
        length = Random.Range(lengthMin, lengthMax);
        sellPricePerLB = sellPricePerLB * weight;
    }
}
