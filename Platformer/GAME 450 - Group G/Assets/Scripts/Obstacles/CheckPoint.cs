using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{

    //The player will respawn at this

    private bool isActive;

    private void Start()
    {
        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.25f);
        isActive = false;
    }

    public void Reset()
    {
            GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.25f);
            isActive = false;
            GetComponent<BoxCollider2D>().enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isActive)
        {
            if (collision == null)
                return;
            if(collision.gameObject.GetComponent<Player>() != null)
            {
                GameManager.checkPoint = transform;
                GetComponent<SpriteRenderer>().color = Color.white;
                isActive = true;
                GetComponent<BoxCollider2D>().enabled = false;
            }

        }
    }
}
