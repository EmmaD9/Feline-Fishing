using UnityEngine;

public class FishingLure
{
    // Fields
    private string name;
    private bool isBought;
    private string fishAttracted;
    private float cost;
    private Texture2D texture;

    // Properties
    public bool IsBought { get => isBought; set => isBought = value; }
    public string FishAttracted { get => fishAttracted;}
    public Texture2D Texture { get => texture;}
    public float Cost { get => cost; set => cost = value; }
    public string Name { get => name; set => name = value; }

    // Constructor

    public FishingLure(string name, bool isBought, string fishAttracted, float cost, Texture2D texture)
    {
        this.isBought = isBought;
        this.fishAttracted = fishAttracted;
        this.texture = texture;
        this.cost = cost;
        this.name = name;
    }
}
