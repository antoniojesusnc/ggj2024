using TMPro;
using UnityEngine;

public class UILevelTimer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timer;

    public void Init()
    {
        _timer.gameObject.SetActive(true);
        
        OnUpdateTime(LevelController.Instance.RemainingTime);
        LevelController.Instance.OnUpdateTime += OnUpdateTime;
    }

    private void OnUpdateTime(float deltaTime)
    {
        _timer.text = $"{deltaTime}s";
    }
}
