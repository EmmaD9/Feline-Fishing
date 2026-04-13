using UnityEngine;

[CreateAssetMenu(fileName = "FishScriptableObject", menuName = "Scriptable Objects/FishScriptableObject")]
public class FishScriptableObject : ScriptableObject
{
    [SerializeField]
    private string fishName;
    [SerializeField]
    private float lengthMin, lengthMax;
    [SerializeField]
    private float health;
    [SerializeField]
    private float sellPricePerLB;
    [SerializeField]
    private Texture2D texture;

    private float sellValue;

    public string FishName { get => fishName; set => fishName = value; }
    public float Health { get => health; set => health = value; }
    public float SellPricePerLB { get => sellPricePerLB; set => sellPricePerLB = value; }
    public float LengthMin { get => lengthMin; set => lengthMin = value; }
    public float LengthMax { get => lengthMax; set => lengthMax = value; }
}
