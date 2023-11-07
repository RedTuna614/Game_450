using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == null)
            return;
        if (collision.gameObject.GetComponent<Player>() != null)
        {
            GameManager.points++;

           // collision.transform.parent.GetComponent<Main>().UpdatePointsText();
            GameManager.Main.GetComponent<Main>().UpdatePointsText();

            gameObject.SetActive(false);
        }
    }
}
