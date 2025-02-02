using UnityEngine;

[CreateAssetMenu(fileName = "TowerUpgradeSO", menuName = "Scriptable Objects/TowerUpgradeSO")]
public class TowerUpgradeSO : ScriptableObject
{
    public string name;
    public string description;
    public Statistics statistics;
}
