using System.Collections;
using System.Collections.Generic;
using Unity.Services.Analytics;
using UnityEngine;

public class AnalyticsOnFailHandler : MonoBehaviour
{
  
    void Start()
    {
        UpdateOnFailEvent();
    }

   
    void UpdateOnFailEvent()
    {
        AnalyticsService.Instance.CustomData("OnFail");
        AnalyticsService.Instance.Flush();
    }
}
