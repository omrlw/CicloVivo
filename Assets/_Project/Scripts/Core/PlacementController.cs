using UnityEngine;

public class PlacementController : MonoBehaviour
{
    public Camera cam;
    public GridSystem grid;
    public GameObject modulePrefab;
    public ModuleDefinition currentDef;

    int runningInstanceId = 1;
    int rotationSteps = 0; // 0,90,180,270

    void Update(){
        if (grid == null || cam == null) return;

        if (Input.GetKeyDown(KeyCode.R)) {
            rotationSteps = (rotationSteps + 1) % 4;
        }

        if (Input.GetMouseButtonDown(0) && currentDef != null){
            if (TryGetCellUnderMouse(out var cell)){
                var size = currentDef.footprintCells;
                if (grid.CanPlace(cell, size)){
                    var pos = grid.CellToWorld(cell);
                    var rot = Quaternion.Euler(0f, rotationSteps * 90f, 0f);
                    var go = Instantiate(modulePrefab, pos, rot);
                    go.name = $"Module_{runningInstanceId}_{currentDef.displayName}";
                    var pm = go.AddComponent<PlacedModule>();
                    pm.Init(runningInstanceId, currentDef, cell);
                    grid.SetOccupancy(runningInstanceId, cell, currentDef.footprintCells, true);
                    runningInstanceId++;
                }
            }
        }

        if (Input.GetMouseButtonDown(1)){
            if (Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out var hit, 500f)){
                var pm = hit.collider.GetComponentInParent<PlacedModule>();
                if (pm != null){
                    grid.ClearInstance(pm.instanceId);
                    Destroy(pm.gameObject);
                }
            }
        }
    }

    bool TryGetCellUnderMouse(out Vector2Int cell){
        cell = default;
        if (Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out var hit, 500f)){
            var p = hit.point;
            int x = Mathf.FloorToInt(p.x / grid.cellSize);
            int y = Mathf.FloorToInt(p.z / grid.cellSize);
            var c = new Vector2Int(x,y);
            if (grid.InBounds(c)){ cell = c; return true; }
        }
        return false;
    }
}