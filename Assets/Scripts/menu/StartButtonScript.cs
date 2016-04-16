using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartButtonScript : MonoBehaviour {

	public void printToConsole()
    {
        Debug.Log("start button pressed");
        SceneManager.LoadScene(1);
    }
}
