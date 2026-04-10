using UnityEngine;

public class TargetOverlap : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other)
    {
        FishingManager.fishHealth--;
        Debug.Log("Overlap");
    }
}
