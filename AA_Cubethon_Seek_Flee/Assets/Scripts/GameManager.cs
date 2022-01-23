using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float restartDelay = 1f;
    bool gameHasEnded = false;

    public GameObject competeLevelUI;

    public void GameOver()
    {
        if (gameHasEnded == false)
        {
            Debug.Log("GameOver");
            gameHasEnded = true;
            Invoke("Restart", restartDelay);
        }

    }


    void Restart()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    public void CompleteLevel()
    {
        competeLevelUI.SetActive(true);
    }


}
