using UnityEngine;

[CreateAssetMenu()]
public class PlantMetaSO : ScriptableObject
{
    public PlantManager.Plant id;
    public Transform prefab;
    public string nickname;
}
