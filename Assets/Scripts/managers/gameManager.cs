using UnityEngine;
using System.Collections;
using System;

public static class gameManager {

    public delegate void GameEvent();
    public static event GameEvent GameStart;
    public static event GameEvent GameOver;
    public static event GameEvent NextLevel;

    public static void TriggerGameStart()
    {
        if (GameStart != null)
            GameStart();
        }

    public static void TriggerNextLevel()
    {
        if (NextLevel != null)
        {
            GUIText text1 = (GUIText)GameObject.FindGameObjectWithTag("WinLoseText").GetComponent<GUIText>();
            text1.text = "You win!\n \n";
            GUIText text2 = (GUIText)GameObject.FindGameObjectWithTag("NextLevelText").GetComponent<GUIText>();
            text2.text = "Get ready for the next level!";
            GUIText text3 = (GUIText)GameObject.FindGameObjectWithTag("GameOverText").GetComponent<GUIText>();
            text3.text = " ";
            GUIText text4 = (GUIText)GameObject.FindGameObjectWithTag("AlienText").GetComponent<GUIText>();
            text4.text = " ";
            NextLevel();
        }
            
    }

    public static void TriggerGameOver(bool win)
    {
        if (!win)
        {
            if (GameOver != null)
            {
                GUIText text = (GUIText) GameObject.FindGameObjectWithTag("WinLoseText").GetComponent<GUIText>();
                text.text = "You Lose";
                GUIText text2 = (GUIText)GameObject.FindGameObjectWithTag("NextLevelText").GetComponent<GUIText>();
                text2.text = " ";
                GUIText text3 = (GUIText)GameObject.FindGameObjectWithTag("AlienText").GetComponent<GUIText>();
                text3.text = " ";
                GameOver();
            }
        }
      
    }
}
