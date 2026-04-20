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
    private float sellValue;
    private Sprite fishSprite;
    private bool caught;

    public string Name { get => name; set => name = value; }
    public float Length { get => length; set => length = value; }
    public float Weight { get => weight; set => weight = value; }
    public float Health { get => health; set => health = value; }
    public float SellValue { get => sellValue; set => sellValue = value; }
    public Sprite FishSprite { get => fishSprite; set => fishSprite = value; }
    public bool Caught { get => caught; set => caught = value; }

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
        caught = false;
    }
}
