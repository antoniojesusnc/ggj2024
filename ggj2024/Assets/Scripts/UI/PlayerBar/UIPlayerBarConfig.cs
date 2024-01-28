using DG.Tweening;
using UnityEngine;

public class UIPlayerBarConfig : ScriptableObject
{
    [field: SerializeField]
    public Vector3 BarOffset { get; private set; }
    
    [field: SerializeField]
    public float FillSpeed { get; private set; }

    [field: SerializeField]
    public Ease Ease { get; private set; }
    
    [field: SerializeField]
    public float DownSpeed { get; private set; }
    
    [field: SerializeField]
    public float IncreasePerInput { get; private set; }

    [field: SerializeField]
    public float MaxPitch { get; private set; }
    
}
