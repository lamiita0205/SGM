using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Level1ButtonScript : MonoBehaviour {

    public void printToConsole()
    {
        Debug.Log("level 1 button pressed");
        SceneManager.LoadScene(3);
    }
}
