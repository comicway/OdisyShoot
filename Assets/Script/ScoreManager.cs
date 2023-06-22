using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    private int score;
    //Para actulizar el score en la UI
    public TMP_Text scoreText;
    public void AddEnemyScore()
    {
        score++;
    }
    void Update()
    {
        scoreText.text = score.ToString();
        //Debug.Log("El puntaje es " + score);
        if (score == 20)
        {
            SceneManager.LoadScene("PlanetLevel2");
        }
    }
}
