using Unity.Services.Analytics;
using Unity.Services.Core;
using UnityEngine;

public class AnalyticInit : MonoBehaviour
{
    async void Start()
    {
        try
        {
            await UnityServices.InitializeAsync();
        }
        catch (ConsentCheckException e)
        {
            Debug.LogError(e.ToString());
        }

    }
  
}
