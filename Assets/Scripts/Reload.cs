using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Reload : MonoBehaviour
{
    public Text lossText;
    public Text winText;
    
    void resetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void quitGame()
    {
        Application.Quit();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y) && lossText.text == "You lost :( Play again? Y/N")
        {
            resetGame();
        }
        else if (Input.GetKeyDown(KeyCode.N) && lossText.text == "You lost :( Play again? Y/N")
        {
            quitGame();
        }
        else if (Input.GetKeyDown(KeyCode.Y) && winText.text == "You Win! Play again? Y/N")
        {
            resetGame();
        }
        else if (Input.GetKeyDown(KeyCode.N) && winText.text == "You Win! Play again? Y/N") {
            quitGame();
        }
    }
}
