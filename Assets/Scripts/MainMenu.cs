﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
    {
         public void PlayGame() 
    {
     UserData.score = 0;
     SceneManager.LoadScene(1);

    }
    public void QuitGame() {
        Debug.Log("QUITTTING");
        Application.Quit();
        }
    //public void LoseGame() {
      //  SceneManager.LoadScene(3);
    //}
}

   