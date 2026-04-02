using UnityEngine;
using UnityEngine.InputSystem;

public class FollowMouse2D : MonoBehaviour
{
    void Update()
    {
        Vector2 mousePos = Mouse.current.position.ReadValue();
        mousePos.y = Mathf.Clamp(mousePos.y, 0, Screen.height);

        Vector3 worldPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 10f));
        transform.position = worldPos;
    }
}