using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class FishingManager : MonoBehaviour
{

    private float timer;
    private bool fishing;
    private bool hooked;
    public GameObject fishingBar;
    public GameObject targetArea;

    private GameObject currentFishingBar;
    private GameObject currentTargetArea;

    private float barMovement;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fishing = false;
        hooked = false;
        targetArea.transform.position = new Vector3(-4.22f, -0.08f, 0);
        fishingBar.transform.position = new Vector3(-4.22f, -0.29f, 0);
        barMovement = 0.005f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.rightButton.wasPressedThisFrame && !fishing)
        {
            StartFishing();
            fishing = true;
        }
        if (hooked)
        {
            if(currentTargetArea.transform.position.y >=2.6 || currentTargetArea.transform.position.y <=  -3.2)
            {
                barMovement *= -1;
            }
            currentTargetArea.transform.position += new Vector3(0, barMovement, 0);
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
        currentFishingBar = Instantiate(fishingBar);
        currentTargetArea = Instantiate(targetArea);
        hooked = true;
    }
}
