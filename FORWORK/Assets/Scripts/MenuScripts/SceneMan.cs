using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneMan : MonoBehaviour
{
    
    public void LoadScene (int _sceneNumber)
    {                          
                SceneManager.LoadScene(_sceneNumber);
                
    }
    public void ExitGame()
    {
        Application.Quit();

    }
    public void BackToTheStart()
    {
        SceneManager.LoadScene("StartScene");
    }
    
}
