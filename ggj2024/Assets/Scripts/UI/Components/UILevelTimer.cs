using TMPro;
using Trials;
using UnityEngine;

public class UILevelTimer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timer;
    [SerializeField] private TextMeshProUGUI _timerOutline;

    public void Init()
    {
        gameObject.SetActive(true);

        var bellySlap = BellySlap.Instance as BellySlap;
        OnUpdateTime(bellySlap.RemainingTime);
        bellySlap.OnUpdateTime += OnUpdateTime;
    }

    private void OnUpdateTime(float deltaTime)
    {
        _timerOutline.text = $"{deltaTime.ToString("#.00")}s";
        _timer.text = $"{deltaTime.ToString("#.00")}s";
    }
}
