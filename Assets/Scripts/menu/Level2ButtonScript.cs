using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Level2ButtonScript : MonoBehaviour {

    public void printToConsole()
    {
        Debug.Log("level 2 button pressed");
        SceneManager.LoadScene(4);
    }
}
