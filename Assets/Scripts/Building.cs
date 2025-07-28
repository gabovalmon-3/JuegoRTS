using UnityEngine;

public abstract class Building : MonoBehaviour
{
    public string buildingName;
    public int cost;

    public virtual void Construct()
    {
        Debug.Log(buildingName + " construido.");
    }
}
