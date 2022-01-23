using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCollision : MonoBehaviour
{
    public playerMovement movement;

    private void OnCollisionEnter(Collision col)
    {
        if (col.collider.tag == "Obsticle")
        {
            GetComponent<playerMovement>().enabled = false;

            FindObjectOfType<GameManager>().GameOver();

        }
    }
}
