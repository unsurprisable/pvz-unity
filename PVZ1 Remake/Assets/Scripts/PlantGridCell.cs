using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlantGridCell
{
    private float width;
    private float height;
    private Vector2 worldPosition;
    
    private int gridX;
    private int gridY;

    public PlantGridCell(Vector2 worldPosition, float width, float height, int gridX, int gridY) 
    {
        this.width = width;
        this.height = height;
        this.worldPosition = worldPosition;
        this.gridX = gridX;
        this.gridY = gridY;
    }

    public bool IsHovered(Vector2 mousePos) {
        float left = worldPosition.x - width/2;
        float right = worldPosition.x + width/2;
        float bottom = worldPosition.y - height/2;
        float top = worldPosition.y + height/2;

        return mousePos.x >= left && mousePos.x < right && mousePos.y >= bottom && mousePos.y < top;
    }

    public int GridX() {
        return gridX;
    }
    public int GridY() {
        return gridY;
    }
    public Vector2Int GetGridCoordinates() {
        return new Vector2Int(gridX, gridY);
    }

    public Vector2 GetWorldPosition() {
        return worldPosition;
    }

}
