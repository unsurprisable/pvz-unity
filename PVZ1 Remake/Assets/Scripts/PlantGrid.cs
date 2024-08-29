using UnityEngine;

public class PlantGrid : MonoBehaviour
{

    public static PlantGrid Instance { get; private set; }

    [SerializeField] private Transform cellPrefab;

    [Space]

    [Tooltip("Width & height of the grid in cells")]
    [SerializeField] private Vector2Int gridDimensions;

    [Space]

    [Tooltip("Top-left corner of the grid")]
    [SerializeField] private Vector2 origin;
    [Tooltip("Width & height of each individual cell")]
    [SerializeField] private Vector2 cellDimensions;



    private Vector2Int nullVector2Int = new Vector2Int(-1, -1);

    private PlantGridCell[][] gridCells;
    private Vector2Int hoveredCell = new Vector2Int(-1, -1);

    private GameObject[] highlightRows;
    private GameObject[] highlightCols;




    private void Awake()
    {
        Instance = this;
        InitializeGrid();
    }


    private void Update()
    {
        UpdateHoveredCell();
    }


    private void InitializeGrid()
    {
        gridCells = new PlantGridCell[gridDimensions.x][];
        highlightCols = new GameObject[gridDimensions.x];
        highlightRows = new GameObject[gridDimensions.y];

        for (int gridX = 0; gridX < gridDimensions.x; gridX++)
        {
            GameObject highlightCol = GameObject.Instantiate(cellPrefab, new Vector2(cellDimensions.x*gridX + cellDimensions.x/2, cellDimensions.y*gridDimensions.y/2) + origin, Quaternion.identity, transform).gameObject;
            highlightCol.transform.localScale = new Vector3(cellDimensions.x, cellDimensions.y * gridDimensions.y);
            highlightCol.SetActive(false);
            highlightCols[gridX] = highlightCol;

            gridCells[gridX] = new PlantGridCell[gridDimensions.y];
            for (int gridY = 0; gridY < gridDimensions.y; gridY++)
            {
                if (gridX == 0)
                {
                    GameObject highlightRow = GameObject.Instantiate(cellPrefab, new Vector2(cellDimensions.x*gridDimensions.x/2, cellDimensions.y*gridY + cellDimensions.y/2) + origin, Quaternion.identity, transform).gameObject;
                    highlightRow.transform.localScale = new Vector3(cellDimensions.x * gridDimensions.x, cellDimensions.y);
                    highlightRow.SetActive(false);
                    highlightRows[gridY] = highlightRow;
                }
                Vector2 position = new Vector2(cellDimensions.x * gridX, cellDimensions.y * gridY) + cellDimensions/2 + origin;
                gridCells[gridX][gridY] = new PlantGridCell(position, cellDimensions.x, cellDimensions.y);
            }
        }
    }



    private void UpdateHoveredCell() 
    {
        bool found = false;
        Vector2Int foundCell = nullVector2Int;
        for (int gridX = 0; gridX < gridDimensions.x; gridX++)
        {
            for (int gridY = 0; gridY < gridDimensions.y; gridY++)
            {
                if (gridCells[gridX][gridY].IsHovered(Camera.main.ScreenToWorldPoint(Input.mousePosition)))
                {
                    found = true;
                    foundCell = new Vector2Int(gridX, gridY);
                    break;
                }
            }
            if (found) break;
        }
        
        if (foundCell.Equals(hoveredCell)) return;
        if (!hoveredCell.Equals(nullVector2Int)) {
            highlightCols[hoveredCell.x].SetActive(false);
            highlightRows[hoveredCell.y].SetActive(false);
        }
        if (found)
        {
            hoveredCell = foundCell;
            highlightCols[hoveredCell.x].SetActive(true);
            highlightRows[hoveredCell.y].SetActive(true);
            return;
        }
        hoveredCell = nullVector2Int;
    }


    public bool TryGetHoveredCell(out PlantGridCell cell)
    {
        if (hoveredCell.Equals(nullVector2Int)) 
        {
            cell = null;
            return false;
        }
        else
        {
            cell = gridCells[hoveredCell.x][hoveredCell.y];
            return true;
        }
    }

}
