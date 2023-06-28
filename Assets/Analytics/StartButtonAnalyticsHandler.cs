using Unity.Services.Analytics;
using UnityEngine;
using UnityEngine.UI;

public class StartButtonAnalyticsHandler : MonoBehaviour
{
    private Button startButton;
    private void Start()
    {
        startButton = GetComponent<Button>();
        startButton.onClick.AddListener(UpdateStartButtonEvent);
    }
    void UpdateStartButtonEvent()
    {
        AnalyticsService.Instance.CustomData("StartButtonClicked");
        AnalyticsService.Instance.Flush();
    }
}
