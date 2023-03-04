using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public static bool GameIsOver = false;

    public GameObject gameOverMenuUI;
    public MainCharControl player;

    // Update is called once per frame
    // void Update()
    // {
    //     Debug.Log(player.currentHealth);
    //     if ((player.currentHealth <= 0) && (!GameIsOver)) {
    //         Debug.Log("Game over. Pausing game");
    //         PauseGame();
    //     }
    // }

    public void GameOver() {
        gameOverMenuUI.SetActive(true);
        Time.timeScale = 0;
        GameIsOver = true;
    }

    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        gameOverMenuUI.SetActive(false);
        Time.timeScale = 1;
        GameIsOver = false;
    }

    public void QuitGame() {
        Debug.Log("Quitting game... Bye!");
        Application.Quit();
    }
}
