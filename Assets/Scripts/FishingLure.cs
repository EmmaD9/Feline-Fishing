using UnityEngine;

public class FishingLure
{
    // Fields
    private bool isBought;
    private FishClass fishAttracted;

    // Properties
    public bool IsBought { get => isBought; set => isBought = value; }
    public FishClass FishAttracted { get => fishAttracted;}

    // Constructor
   
    public FishingLure(bool isBought,FishClass fishAttracted)
    {
        this.isBought = isBought;
        this.fishAttracted = fishAttracted;
    }
}
