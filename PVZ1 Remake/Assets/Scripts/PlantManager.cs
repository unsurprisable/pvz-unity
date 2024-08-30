using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantManager : MonoBehaviour
{
    public static PlantManager Instance { get; private set; }

    public enum Plant {
        PEASHOOTER,
        SUNFLOWER,
        WALLNUT,
    }

    [SerializeField] private PlantMetaListSO plantMetaContainer;

    private Dictionary<Plant, PlantMetaSO> plantDictionary = new Dictionary<Plant, PlantMetaSO>();

    private void Awake()
    {
        Instance = this;
        // initialize id-to-meta dictionary
        foreach (PlantMetaSO p in plantMetaContainer.list) {
            plantDictionary[p.id] = p;
        }
    }

    public PlantMetaSO GetPlantMeta(Plant id) {
        if (plantDictionary.TryGetValue(id, out PlantMetaSO meta)) {
            return meta;
        } else {
            Debug.LogError("Tried to retrieve meta of " + id.ToString() + ", but it was not added to the PlantMetaListSO!");
            return null;
        }
    }
}
