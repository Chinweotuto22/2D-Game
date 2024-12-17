using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private bool isGameOver = false;

   // void Awake()
   // {
    //    if (instance == null)
     //   {
     //       instance = this;
     //   }
     //   else
    //    {
    //        Destroy(gameObject);
     //   }

     //   DontDestroyOnLoad(gameObject);
   // }

    public void GameOver()
    {
        isGameOver = true;
        Time.timeScale = 0f; // Optional: Pause the game
    }

    public bool IsGameOver()
    {
        return isGameOver;
    }
}
