using DG.Tweening;
using UnityEngine;

public class UIEndLevelConfig : ScriptableObject
{
    [field: SerializeField] 
    public float TextFinalScale { get; private set; }
    
    [field: SerializeField] 
    public float TextFinalDuration { get; private set; }
    
    [field: SerializeField]
    public Ease TextFinalEase { get; private set; }
    
    [field: SerializeField]
    public float TimeToLaugh { get; set; }
    
    [field: SerializeField] 
    public float TextWinnerScale { get; private set; }
    
    [field: SerializeField] 
    public float TextWinnerDuration { get; private set; }
    
    [field: SerializeField]
    public Ease TextWinnerEase { get; private set; }
    
    [field: SerializeField] 
    public float TextWinnerIdleScale { get; private set; }
    
    [field: SerializeField] 
    public float TextWinnerIdleDuration { get; private set; }
    
    [field: SerializeField]
    public Ease TextWinnerIdleEase { get; private set; }
}
