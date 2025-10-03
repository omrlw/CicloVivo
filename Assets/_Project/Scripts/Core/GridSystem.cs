using UnityEngine;

public class GridSystem : MonoBehaviour
{
    [Header("Grid")]
    public int width = 20;
    public int height = 12;
    public float cellSize = 1f;

    int[,] occupancy; // -1 libre, >=0 id de instancia

    void Awake() => InitGrid();

    void InitGrid() {
        occupancy = new int[width, height];
        for (int x=0;x<width;x++)
            for (int y=0;y<height;y++)
                occupancy[x,y] = -1;
    }

    public bool InBounds(Vector2Int c) => c.x>=0 && c.y>=0 && c.x<width && c.y<height;
    public Vector3 CellToWorld(Vector2Int c) => new Vector3(c.x * cellSize, 0f, c.y * cellSize);

    public bool CanPlace(Vector2Int origin, Vector2Int size){
        for (int dx=0; dx<size.x; dx++)
        for (int dy=0; dy<size.y; dy++){
            var p = new Vector2Int(origin.x+dx, origin.y+dy);
            if (!InBounds(p) || occupancy[p.x,p.y] != -1) return false;
        }
        return true;
    }

    public void SetOccupancy(int instanceId, Vector2Int origin, Vector2Int size, bool occupy){
        for (int dx=0; dx<size.x; dx++)
        for (int dy=0; dy<size.y; dy++){
            var p = new Vector2Int(origin.x+dx, origin.y+dy);
            occupancy[p.x,p.y] = occupy ? instanceId : -1;
        }
    }

    public void ClearInstance(int instanceId){
        for (int x=0;x<width;x++)
        for (int y=0;y<height;y++)
            if (occupancy[x,y] == instanceId) occupancy[x,y] = -1;
    }
}