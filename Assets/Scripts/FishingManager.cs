using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class FishingManager : MonoBehaviour
{

    private float timer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.rightButton.wasPressedThisFrame)
        {
            StartFishing();
        }
    }

    public void StartFishing()
    {
        Debug.Log("Started Fishing");
        timer = Random.Range(2.0f, 10.0f);
        Debug.Log("Time: " + timer);
        StartCoroutine(Timer(timer));
    }

    private IEnumerator Timer(float time)
    {
        yield return new WaitForSeconds(time);
        Debug.Log("Timer Finished");
    }
}
