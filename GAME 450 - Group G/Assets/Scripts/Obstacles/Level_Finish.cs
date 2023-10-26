using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Finish : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == null)
            return;
        if(collision.gameObject.GetComponent<Player>() != null)
        {
            if(collision.transform.parent != GameManager.Main)
            {
                collision.transform.SetParent(GameManager.Main.transform, true);
            }
            if(GameManager.currentLevel + 1 < GameManager.maxLevels)
            {
                //collision.transform.parent.GetComponent<Main>().NextLevel();
                GameManager.Main.GetComponent<Main>().NextLevel();
            }
        }
    }
}
