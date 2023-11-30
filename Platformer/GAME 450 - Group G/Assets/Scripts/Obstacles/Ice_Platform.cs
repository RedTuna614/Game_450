using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice_Platform : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision == null)
        {
            return;
        }
           
        if(collision.gameObject.GetComponent<Player>() != null)
        {
            collision.gameObject.GetComponent<Player>().SetisSliding(true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision == null)
        {
            return;
        }

        if(collision.gameObject.GetComponent<Player>() != null)
        {
            collision.gameObject.GetComponent <Player>().SetisSliding(false);
            collision.gameObject.GetComponent <Player>().ResetVelocity();
        }
    }
}
