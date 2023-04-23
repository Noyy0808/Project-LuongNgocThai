using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class FinishScreen : MonoBehaviour
{

    public GameObject gameFinishMenu;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // T?m d?ng th?i gian trong trò ch?i

            Time.timeScale = 0f;
            // Hi?n th? menu game over
            gameFinishMenu.SetActive(true);

        }
    }

    public void Nextlevel()
    {
        SceneManager.LoadScene(1);
        CloseGameFinishMenu();
    }

    public void BackMenu()
    {
        SceneManager.LoadScene(0);
        CloseGameFinishMenu();
    }

    public void CloseGameFinishMenu()
    {
        // T?t hi?n th? menu game over
        gameFinishMenu.SetActive(false);

        // Ti?p t?c ch?y th?i gian trong trò ch?i
        Time.timeScale = 1f;

    }



}



