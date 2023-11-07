using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Extra_Life : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == null)
            return;
        if(collision.gameObject.GetComponent<Player>() != null)
        {
            if((GameManager.currentLives + 1) > GameManager.maxlives)
            {
                GameManager.points += 100;
                GameManager.Main.GetComponent<Main>().UpdatePointsText();
                //collision.transform.parent.GetComponent<Main>().UpdatePointsText();
            }
            else
            {
                GameManager.currentLives++;
                GameManager.Main.GetComponent<Main>().UpdateLifeText();
                //collision.transform.parent.GetComponent<Main>().UpdateLifeText();
            }

            gameObject.SetActive(false);

        }
    }
}
