using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject Menu;

    // Start is called before the first frame update
    void Start()
    {
        FocusPlayer.Pause = false;

        Menu.SetActive(false);
    }
}
