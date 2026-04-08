using UnityEngine;

[CreateAssetMenu(fileName = "LureScriptableObject", menuName = "Scriptable Objects/LureScriptableObject")]
public class LureScriptableObject : ScriptableObject
{
    [SerializeField]
    private string lureName;
    [SerializeField]
    private string fishAttracted;
    [SerializeField]
    private float cost;
    [SerializeField]
    private Texture2D texture;

    public string LureName { get => lureName; }
    public string FishAttracted { get => fishAttracted; }
    public float Cost { get => cost;}
    public Texture2D Texture { get => texture;}
}
