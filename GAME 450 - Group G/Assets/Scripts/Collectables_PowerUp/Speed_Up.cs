using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed_Up : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == null)
            return;
        if(collision.gameObject.GetComponent<Player>() != null)
        {
            GameManager.playerMovementSpeed *= 2;
            StartCoroutine(PowerDown());

            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            for(int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).GetComponent<SpriteRenderer>().enabled = false;
            }

        }
    }

    private IEnumerator PowerDown()
    {
        yield return new WaitForSeconds(5f);

        GameManager.playerMovementSpeed /= 2;

        gameObject.SetActive(false);
    }
}
