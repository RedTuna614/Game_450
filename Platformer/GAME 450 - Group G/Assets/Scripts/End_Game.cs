using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class End_Game : MonoBehaviour
{
    public GameObject Win_Text;

    private void OnEnable()
    {
        Win_Text.GetComponent<TextMesh>().text = ("Total Points: " + GameManager.points);

        GameManager.Main.GetComponent<Main>().EndTimer();
    }
}
