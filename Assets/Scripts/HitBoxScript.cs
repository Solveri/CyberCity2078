using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxScript : MonoBehaviour
{
    public GameObject HitBox;
    public GameObject AirHitBox;

    void Start()
    {
        HitBox.SetActive(false);
        AirHitBox.SetActive(false);
    }

    public void TurnOnGroundHitBox()
    {
        HitBox.SetActive(true);
    }
    public void TurnOffGroundHitBox()
    {
        HitBox.SetActive(false);
    }

    public void TurnOnAirHitBox()
    {
        AirHitBox.SetActive(true);
    }
    public void TurnOffAirHitBox()
    {
        AirHitBox.SetActive(false);
    }
}
