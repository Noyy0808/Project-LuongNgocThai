using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Ui : MonoBehaviour
{
    
    public void Play()
    {
        SceneManager.LoadScene(1);
    }
    public void Quit()
    {
        Application.Quit();
    }


    public void Nextlevel()
    {
        SceneManager.LoadScene(1);
       

    }

    public void BackMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Map1()
    {
        SceneManager.LoadScene(2);
    }

    public void Map2()
    {
        SceneManager.LoadScene(3);
    }

    public void Map3()
    {
        SceneManager.LoadScene(4);
    }
}
