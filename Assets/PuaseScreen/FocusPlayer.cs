using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FocusPlayer : MonoBehaviour
{
    [SerializeField] Button PauseButton;
    [SerializeField] GameObject PauseMenu;

    public static bool Pause;

    private void OnApplicationFocus(bool focus)
    {
        if(!focus)
        {
            PauseButton.onClick.Invoke();

            PauseMenu.SetActive(!focus);
        }
    }

    public void GamePaused()
    {
        Pause = true;
    }

    public void GameCountinued()
    {
        Pause = false;
    }
}
