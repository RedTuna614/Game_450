using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public Transform CheckPoints, Collectables, PowerUps;

    public void ResetLevel()
    {
        ResetCheckPoints();
        ResetCollectables();
        ResetPower_Ups();
    }

    private void ResetCheckPoints()
    {
        for(int i = 0; i < CheckPoints.childCount; i++)
        {
            CheckPoints.GetChild(i).GetComponent<CheckPoint>().Reset();
        }
    }

    private void ResetPower_Ups()
    {
        for(int i = 0; i < PowerUps.childCount; i++)
        {
            PowerUps.GetChild(i).gameObject.SetActive(true);
        }
    }

    private void ResetCollectables()
    {
        for(int i = 0; i < Collectables.childCount; i++)
        {
            Collectables.GetChild(i).gameObject.SetActive(true);
        }
    }

}
