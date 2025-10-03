using UnityEngine;

[CreateAssetMenu(menuName = "CicloVivo/MissionProfile")]
public class MissionProfile : ScriptableObject
{
    public string missionName;
    public int crewCount = 4;
    public int days = 90;
    public float baseAvailablePowerKW = 20f;
    public float requiredExerciseHrsPerCrewPerDay = 2f;
    public bool leo, lunar, martian;
}