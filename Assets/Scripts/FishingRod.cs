using UnityEngine;
using UnityEngine.Rendering;

public class FishingRod
{
    private string name;
    private float power;
    private float cost;
    private bool isBought;
    private Texture2D texture;
    public float Power { get => power; }
    public float Cost { get => cost;}
    public bool IsBought { get => isBought; set => isBought = value; }
    public string Name { get => name; }

    public FishingRod(string name, float power, float cost, bool isBought, Texture2D texture)
    {
        this.power = power;
        this.cost = cost;
        this.isBought = isBought;
        this.texture = texture;
        this.name = name;
    }

}
