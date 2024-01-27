using UnityEngine;

public class LevelConfig : ScriptableObject
{
    [field: SerializeField]
    public int LevelDuration { get; private set; }
}
