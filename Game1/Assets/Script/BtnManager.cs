using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnManager : MonoBehaviour
{
    public void NewGameBtn(string newGame)
    {
        SceneManager.LoadScene(newGame);
    }
    public void LoadGameBtn(string loadGame)
    {
        SceneManager.LoadScene(loadGame);
    }
    public void QuitGameBtn()
    {
        Application.Quit();
    }
}
