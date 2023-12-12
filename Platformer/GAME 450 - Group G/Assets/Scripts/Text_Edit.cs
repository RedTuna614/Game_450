using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Text_Edit : MonoBehaviour
{
    public Text Points;
    public Text Time;
    public Text Lives;

    private void Awake()
    {
        Points.color = Color.white;
        Time.color = Color.white;
        Lives.color = Color.white;
    }
}
