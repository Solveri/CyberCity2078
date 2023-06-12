using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    [SerializeField] AmmoManagement am;
    public TextMeshProUGUI rounds;

    private void Start()
    {
        rounds.text = am.currentBulletsInMagazine.ToString();
    }

    public void UpdateAmmoText()
    {
        rounds.text = am.currentBulletsInMagazine.ToString();
    }
}
