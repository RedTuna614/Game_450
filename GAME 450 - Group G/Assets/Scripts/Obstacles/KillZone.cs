using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{

    //If the Player enters the trigger area they die.  Use this to prevent the player from falling infinitly

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == null)
            return;
        if (collision.gameObject.GetComponent<Player>() != null)
        {
            //collision.transform.parent.GetComponent<Main>().PlayerDied();
            GameManager.Main.GetComponent<Main>().PlayerDied();
        }
    }
}
