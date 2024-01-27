using DG.Tweening;
using UnityEngine;

public class UIEndLevelPlayerBarConfig : ScriptableObject
{
    [field: SerializeField]
    public float FillSpeed { get; private set; }

    [field: SerializeField]
    public Ease Ease { get; private set; }
    
    [field: SerializeField]
    public float MaxPitch { get; private set; }
}
