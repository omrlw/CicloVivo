using UnityEngine;

public class PlacedModule : MonoBehaviour
{
    public int instanceId;
    public ModuleDefinition def;
    public Vector2Int originCell;

    public void Init(int id, ModuleDefinition d, Vector2Int cell){
        instanceId = id;
        def = d;
        originCell = cell;
    }
}