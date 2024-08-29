
using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class PlantManager : MonoBehaviour
{

    public static PlantManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }


    [SerializeField] private Transform[] prefabsById;

    public Plant Plant<T>(PlantGridCell cell) where T : Plant {
        Type plantType = typeof(T);
        FieldInfo idField = plantType.GetField("ID", BindingFlags.Static | BindingFlags.Public);

        if (idField == null) {
            Debug.LogError("Tried to spawn a plant without an ID!");
            return null;
        }
        
        uint id = (uint)idField.GetValue(null);
        Transform plantTransform = Instantiate(prefabsById[id], cell.GetWorldPosition(), Quaternion.identity);
        return plantTransform.GetComponent<Plant>();
    }

    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (PlantGrid.Instance.TryGetHoveredCell(out PlantGridCell cell))
            {
                Debug.Log("clicked a cell at " + cell.GetGridCoordinates());
                cell.PlacePlant();
            }
        }
    }
}
