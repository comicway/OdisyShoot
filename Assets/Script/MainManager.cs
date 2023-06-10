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
    public void Quit()
    {
        Application.Quit();
    } 
}
