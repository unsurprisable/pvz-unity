using UnityEngine;

[CreateAssetMenu()]
public class PlantMetaSO : ScriptableObject
{
    // public PlantManager.Plant id;
    public string nickname;
    [Space]
    public Transform plantPrefab;
    public Transform seedPrefab;

}
