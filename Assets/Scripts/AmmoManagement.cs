using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AmmoManagement : MonoBehaviour
{
    public int MagazineSize = 30;
    public int currentBulletsInMagazine;
    public bool isMagEmpty;




    private void Awake()
    {
        currentBulletsInMagazine = MagazineSize;
    }

    public void CheckMagCapacity()
    {
        if (currentBulletsInMagazine <= 0)
        {
            isMagEmpty = true;
        }
        else
        {
            isMagEmpty = false;
        }
    }

   

}
