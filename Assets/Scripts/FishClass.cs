using UnityEngine;

public enum Region
{
    Anywhere,

}

public class FishClass
{
    // Fields
    private string name;
    private float length;
    private float weight;
    private float health;
    private float sellPricePerLB;
    private float sellValue;
    private Sprite fishSprite;

    // Properties
    public string Name { get => name;}
    public float Length { get => length;}
    public float Weight { get => weight;}
    public float Health { get => health;}
    public float SellValue { get => sellValue;}
    public Sprite FishSprite { get => fishSprite; set => fishSprite = value; }


    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="name">Species of Fish</param>
    /// <param name="minLength">Minimum possible length</param>
    /// <param name="maxLength">Maximum possible length</param>
    /// <param name="sellPrice"></param>
    /// <param name="fishSprite"></param>
    public FishClass(string name, float minLength, float maxLength, Sprite fishSprite, float sellPricePerLB)
    {
        this.name = name;
        length = Random.Range(minLength, maxLength);
        weight = length * length * length;
        health = weight * 2;
        sellValue = sellPricePerLB * weight;
        this.fishSprite = fishSprite;
    }
}
