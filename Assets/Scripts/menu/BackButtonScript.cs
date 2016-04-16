using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BackButtonScript : MonoBehaviour {

    public void printToConsole()
    {
        Debug.Log("back button pressed");
        SceneManager.LoadScene(0);
    }
}
