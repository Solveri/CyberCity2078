using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FocusPlayer : MonoBehaviour
{
    [SerializeField] Button PauseButton;
    [SerializeField] GameObject PauseMenu;

    private void OnApplicationFocus(bool focus)
    {
        if(!focus)
        {
            PauseButton.onClick.Invoke();

            PauseMenu.SetActive(true);
        }
    }
}
