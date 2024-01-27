using DG.Tweening;
using UnityEngine;

public class UIEndLevelPlayerBarConfig : ScriptableObject
{
    [field: SerializeField]
    public float FillSpeed { get; private set; }

    [field: SerializeField]
    public Ease Ease { get; private set; }
}
