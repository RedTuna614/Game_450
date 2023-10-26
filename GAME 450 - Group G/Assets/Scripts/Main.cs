using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Main : MonoBehaviour
{
    public Text lifeText, timeText, pointText;
    public GameObject Levels, Player;

    private float timeRemaining;

    private void Start()
    {
        GameManager.Reset();
        Reset();
        StartCoroutine(TimeStart());

        GameManager.Main = this.gameObject;
        GameManager.maxLevels = Levels.transform.childCount;

        for(int i = 1; i < GameManager.maxLevels; i++)
        {
            Levels.transform.GetChild(i).gameObject.SetActive(false);
        }

    }

    public void UpdateLifeText()
    {
       lifeText.text = "Lives: " + GameManager.currentLives.ToString();
    }

    public void PlayerDied()
    {
        GameManager.currentLives--;
        GameManager.points = 0;
        UpdatePointsText();
        UpdateLifeText();

        if(GameManager.currentLives == 0)
        {
            int currentLevel = GameManager.currentLevel;
            GameManager.Reset();
            GameManager.currentLevel = currentLevel;
            Respawn(false, true);
        }
        else
        {
            Respawn(false, false);
        }
        

    }

    public void UpdatePointsText()
    {
        pointText.text = "Points: " + GameManager.points.ToString();
    }

    public void NextLevel()
    {
        Levels.transform.GetChild(GameManager.currentLevel).gameObject.SetActive(false);
        GameManager.currentLevel++;
        Levels.transform.GetChild(GameManager.currentLevel).gameObject.SetActive(true);
        GameManager.checkPoint = null;
        StopCoroutine(TimeStart());
        GameManager.points += Mathf.RoundToInt(timeRemaining);
        Respawn(false, false);
        StartCoroutine(TimeStart());
    }

    private void Reset()
    {
        UpdateLifeText();
        UpdatePointsText();
        timeText.text = "Time Remaining: \n  2:00";
        
    }

    private void TimeOut()
    {
        int currentLevel = GameManager.currentLevel;
        GameManager.points = 0;
        GameManager.checkPoint = null;
        GameManager.currentLevel = currentLevel;

        UpdatePointsText();

        Respawn(true, false);

        StartCoroutine(TimeStart());

    }

    private void Respawn(bool timeOut, bool noLives)
    {
        if(GameManager.checkPoint == null) //So the player can respawn at level start if they haven't reached a checkpoint
        {
            Player.transform.position = Levels.transform.GetChild(GameManager.currentLevel).transform.position;
        }
        else if(timeOut || noLives) //If the player dies or runs out of time
        {
            Player.transform.position = Levels.transform.GetChild(GameManager.currentLevel).transform.position;
            Levels.transform.GetChild(GameManager.currentLevel).GetComponent<Level>().ResetLevel();
        }
        else //If the player loses a life but has more than 0 and the time has not ran out
        {
            Player.transform.position = GameManager.checkPoint.position;
        }

        Player.GetComponent<Player>().ResetPlayer();

    }

    private IEnumerator TimeStart()
    {

        for (float i = GameManager.maxTime; i > 0; i -= (Time.deltaTime/60))
        {
            timeRemaining = i;

            timeText.text = "Time Remaining: \n " + i.ToString();

            yield return null;
        }

        TimeOut();

    }
}
