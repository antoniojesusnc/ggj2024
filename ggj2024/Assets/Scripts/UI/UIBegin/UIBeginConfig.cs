using DG.Tweening;
using UnityEngine;

public class UIBeginConfig : ScriptableObject
{
    [field: SerializeField, Header("texts")]
    public int Countdown { get; private set; }
    
    [field: SerializeField, Header("texts")]
    public string InitialText { get; private set; }
    [field: SerializeField]
    public string FinalText { get; private set; }
    
    [field: SerializeField, Header("Number")]
    public Vector3 NumberScale { get; private set; }
    [field: SerializeField]
    public float NumberTime { get; private set; }
    [field: SerializeField]
    public Ease NumberEase { get; private set; }
    [field: SerializeField]
    public float TimeToBeginFadeOut { get; private set; }
    [field: SerializeField]
    public float TimeBetweenNumbers { get; private set; }
}
