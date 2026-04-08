using UnityEngine;
using UnityEngine.Rendering;

public class FishingRod
{

    private float power;
    private float cost;
    private bool isBought;
    public float Power { get => power; }
    public float Cost { get => cost;}
    public bool IsBought { get => isBought; set => isBought = value; }

    public FishingRod(float power, float cost, bool isBought)
    {
        this.power = power;
        this.cost = cost;
        this.isBought = isBought;
    }

}
