using UnityEngine;

public enum ModuleCategory { Waste, Thermal, LifeSupport, Comms, Power, Storage, Galley, Med, CrewQuarters, Exercise }

[CreateAssetMenu(menuName = "CicloVivo/ModuleDefinition")]
public class ModuleDefinition : ScriptableObject
{
    public string displayName;
    public ModuleCategory category;
    public Vector2Int footprintCells = new Vector2Int(2,1);
    public float massKg;
    public float powerGenKW;   // + genera
    public float powerUseKW;   // + consume
    public float heatRejectKW; // + rechaza calor
    public float heatLoadKW;   // + carga térmica
    public float o2SupplyKgPerDay;
    public float co2RemovalKgPerDay;
    public float waterRecycleLPerDay;
    public int crewCapacity;
    public bool requiresPressurePath = true;
}