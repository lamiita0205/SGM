using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class OptionButtonScript : MonoBehaviour {

    public void printToConsole()
    {
        Debug.Log("options button pressed");
        SceneManager.LoadScene(2);
    }
}
