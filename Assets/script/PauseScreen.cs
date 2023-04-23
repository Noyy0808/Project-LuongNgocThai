using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour
{
    public GameObject gamePauseMenu;

    public void ShowGamePausehMenu()
    {
        gamePauseMenu.SetActive(true); // Hi?n th? game object
        Time.timeScale = 0f;
    }


    public void BackMenu()
    {
        SceneManager.LoadScene(0);
        CloseGamePauseMenu();
    }

    public void CloseGamePauseMenu()
    {
        // T?t hi?n th? menu game over
        gamePauseMenu.SetActive(false);

        // Ti?p t?c ch?y th?i gian trong trò ch?i
        Time.timeScale = 1f;

    }

}
