using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
    public void ChangeScene()
    {
        SceneManager.LoadScene("PlanetLevel1");
    }
    public void GoToCredit()
    {
        SceneManager.LoadScene("Creditos");
    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
