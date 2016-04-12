using UnityEngine;
using UnityEngine.SceneManagement;

public class GUIManager : MonoBehaviour
{

    public GUIText gameOverText;
    public GUIText instructionsText;
    public GUIText alienText;
    public GUIText winLoseText;
    public GUIText nextLevelText;

    void Start()
    {
        gameOverText = (GUIText)GameObject.FindGameObjectWithTag("GameOverText").GetComponent<GUIText>();
        instructionsText = (GUIText)GameObject.FindGameObjectWithTag("Instruction").GetComponent<GUIText>();
        alienText = (GUIText) GameObject.FindGameObjectWithTag("AlienText").GetComponent<GUIText>();
        winLoseText = (GUIText)GameObject.FindGameObjectWithTag("WinLoseText").GetComponent<GUIText>();
        nextLevelText = (GUIText)GameObject.FindGameObjectWithTag("NextLevelText").GetComponent<GUIText>();
        Debug.Log("start " + (alienText != null));

        gameManager.GameStart += GameStart;
        gameManager.GameOver += GameOver;
        gameManager.NextLevel += NextLevel;

        gameOverText.enabled = false;
        alienText.enabled = false;
        instructionsText.enabled = false;
        winLoseText.enabled = false;
        nextLevelText.enabled = false;

        Debug.Log("WE ARE IN THE START");
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.J))
        {
            if (gameOverText.enabled)
            {
                gameManager.GameStart -= GameStart;
                gameManager.GameOver -= GameOver;
                gameManager.NextLevel -= NextLevel;

                SceneManager.LoadScene(0);
            }
            else if(nextLevelText.enabled)
            {
                gameManager.GameStart -= GameStart;
                gameManager.GameOver -= GameOver;
                gameManager.NextLevel -= NextLevel;

                SceneManager.LoadScene(1);
            }
            gameManager.TriggerGameStart();
        }
    }

    private void GameStart()
    {
        gameOverText.enabled = false;
        alienText.enabled = false;
        instructionsText.enabled = false;
        winLoseText.enabled = false;
        nextLevelText.enabled = false;
    }

    private void GameOver()
    {
        Debug.Log(gameOverText != null);
        gameOverText.enabled = true;
        alienText.enabled = false;
        instructionsText.enabled = true;
        winLoseText.enabled = true;
        nextLevelText.enabled = false;
    }

    private void NextLevel()
    {
        gameOverText.enabled = false;
        alienText.enabled = false;
        instructionsText.enabled = true;
        winLoseText.enabled = true;
        nextLevelText.enabled = true;
    }
}