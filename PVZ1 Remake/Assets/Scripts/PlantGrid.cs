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


    private PlantGridCell[][] gridCells;
    private PlantGridCell hoveredCell = null;

    private GameObject[] highlightRows;
    private GameObject[] highlightCols;

    private bool isDisabled = true;




    private void Awake()
    {
        Instance = this;
        InitializeGrid();
    }


    private void Update()
    {
        if (isDisabled) return;
        UpdateHoveredCell();
    }


    private void InitializeGrid()
    {
        gridCells = new PlantGridCell[gridDimensions.x][];
        highlightCols = new GameObject[gridDimensions.x];
        highlightRows = new GameObject[gridDimensions.y];

        for (int gridX = 0; gridX < gridDimensions.x; gridX++)
        {
            GameObject highlightCol = Instantiate(cellPrefab, new Vector2(cellDimensions.x*gridX + cellDimensions.x/2, cellDimensions.y*gridDimensions.y/2) + origin, Quaternion.identity, transform).gameObject;
            highlightCol.transform.localScale = new Vector3(cellDimensions.x, cellDimensions.y * gridDimensions.y);
            highlightCol.GetComponent<SpriteRenderer>().sortingOrder = -5;
            highlightCol.SetActive(false);
            highlightCols[gridX] = highlightCol;

            gridCells[gridX] = new PlantGridCell[gridDimensions.y];
            for (int gridY = 0; gridY < gridDimensions.y; gridY++)
            {
                if (gridX == 0)
                {
                    GameObject highlightRow = Instantiate(cellPrefab, new Vector2(cellDimensions.x*gridDimensions.x/2, cellDimensions.y*gridY + cellDimensions.y/2) + origin, Quaternion.identity, transform).gameObject;
                    highlightRow.transform.localScale = new Vector3(cellDimensions.x * gridDimensions.x, cellDimensions.y);
                    highlightRow.GetComponent<SpriteRenderer>().sortingOrder = -5;
                    highlightRow.SetActive(false);
                    highlightRows[gridY] = highlightRow;
                }
                Vector2 position = new Vector2(cellDimensions.x * gridX, cellDimensions.y * gridY) + cellDimensions/2 + origin;
                gridCells[gridX][gridY] = new PlantGridCell(position, cellDimensions.x, cellDimensions.y, gridX, gridY);
            }
        }
    }



    private void UpdateHoveredCell() 
    {
        PlantGridCell foundCell = null;
        ForEachCell((cell) => {
            if (cell.IsHovered(Camera.main.ScreenToWorldPoint(Input.mousePosition))) {
                foundCell = cell;
                return;
            }
        });

        if (hoveredCell != null) {
            highlightCols[hoveredCell.GridX()].SetActive(false);
            highlightRows[hoveredCell.GridY()].SetActive(false);
        }

        hoveredCell = foundCell;
        if (hoveredCell != null) {
            highlightCols[hoveredCell.GridX()].SetActive(true);
            highlightRows[hoveredCell.GridY()].SetActive(true);
        }
    }

    public bool TryGetHoveredCell(out PlantGridCell cell)
    {
        cell = hoveredCell;
        return hoveredCell != null;
    }


    public delegate void CellAction(PlantGridCell cell);
    public void ForEachCell(CellAction runnable)
    {
        foreach (PlantGridCell[] colCells in gridCells) {
            foreach (PlantGridCell cell in colCells) {
                runnable(cell);
            }
        }
    }

    public void Enable() {
        isDisabled = false;
    }
    public void Disable() {
        isDisabled = true;
        if (hoveredCell != null) {
            highlightCols[hoveredCell.GridX()].SetActive(false);
            highlightRows[hoveredCell.GridY()].SetActive(false);
        }
    }

    public void PlantSeed(PlantMetaSO plantMeta, PlantGridCell cell) {
        if (cell.HasPlant()) {
            Debug.LogError("cannot plant on an occupied space! location: " + cell.GetGridCoordinates());
            return;
        }
        cell.SetPlant(plantMeta);
        Instantiate(plantMeta.plantPrefab, cell.GetWorldPosition(), Quaternion.identity);
        Debug.Log("planted " + plantMeta.nickname + " at cell " + cell.GetGridCoordinates());
    }
}
