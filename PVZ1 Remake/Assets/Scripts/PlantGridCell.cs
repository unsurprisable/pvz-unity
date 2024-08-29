using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlantGridCell
{
    private float width;
    private float height;
    private Vector2 worldPosition;

    private Plant plant;

    public PlantGridCell(Vector2 worldPosition, float width, float height) 
    {
        this.width = width;
        this.height = height;
        this.worldPosition = worldPosition;
    }

    public bool IsHovered(Vector2 mousePos) {
        float left = worldPosition.x - width/2;
        float right = worldPosition.x + width/2;
        float bottom = worldPosition.y - height/2;
        float top = worldPosition.y + height/2;

        return mousePos.x >= left && mousePos.x < right && mousePos.y >= bottom && mousePos.y < top;
    }


    public void PlacePlant()
    {
        Debug.Log("hi");
    }

}
