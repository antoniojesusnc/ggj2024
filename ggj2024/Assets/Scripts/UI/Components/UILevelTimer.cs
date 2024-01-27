using TMPro;
using UnityEngine;

public class UILevelTimer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timer;

    private void Start()
    {
        LevelController.Instance.OnLevelBegin += OnLevelBegin;
        LevelController.Instance.OnUpdateTime += OnUpdateTime;
        LevelController.Instance.OnLevelFinish += OnLevelFinish;
    }

    private void OnLevelBegin()
    {
        _timer.gameObject.SetActive(true);
        OnUpdateTime(LevelController.Instance.RemainingTime);
    }


    private void OnUpdateTime(float deltaTime)
    {
        _timer.text = $"{deltaTime}s";
    }
    private void OnLevelFinish()
    {
        _timer.gameObject.SetActive(false);
    }
}
