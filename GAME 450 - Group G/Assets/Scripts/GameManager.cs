using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager
{
    public static Transform checkPoint = null;
    public static GameObject Main = null;

    public static bool resetCheckpoints = false;
    public static int maxlives = 5;
    public static int points = 0;
    public static int currentLives = 5;
    public static int currentLevel = 0;
    public static int maxLevels = 3;
    public static float playerMovementSpeed = 10f;
    public static float timeRemaining = 2f;
    public static float maxTime = 2f;


    public static void Reset()
    {
        resetCheckpoints = false;
        checkPoint = null;
        currentLevel = 0;
        points = 0;
        playerMovementSpeed = 10f;
        currentLives = maxlives;
        playerMovementSpeed = 10f;
        timeRemaining = maxTime;
    }
}
