using UnityEngine;

[CreateAssetMenu(fileName = "RodScriptableObject", menuName = "Scriptable Objects/RodScriptableObject")]
public class RodScriptableObject : ScriptableObject
{
    [SerializeField]
    private string rodName;
    [SerializeField]
    private float power;
    [SerializeField]
    private float cost;
    [SerializeField]
    private Texture2D texture;

    public string RodName { get => rodName; set => rodName = value; }
    public float Power { get => power; set => power = value; }
    public float Cost { get => cost; set => cost = value; }
    public Texture2D Texture { get => texture; set => texture = value; }
}
