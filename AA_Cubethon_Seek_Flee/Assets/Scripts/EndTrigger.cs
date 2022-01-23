using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{

    public GameManager gameManager;

    private void OnTriggerEnter(Collider col)
    {   
        if(col.gameObject.CompareTag("Player"))
            gameManager.CompleteLevel();
    }

}
