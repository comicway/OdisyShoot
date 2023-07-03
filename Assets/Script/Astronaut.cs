using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms.Impl;

public class Astronaut : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject efect;
    private float cantPiza = 0f;
    //GameOver Text
    public TMP_Text gameOverText;
    public TMP_Text scoreText;
    // UI Fichas
    [SerializeField] public Image imagenUI1;
    [SerializeField] public Image imagenUI2;
    public void InstanciarEfecto()
    {
        Instantiate(efect, transform.position, transform.rotation);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Anillo"))
        {
            Destroy(gameObject);
            InstanciarEfecto();
            gameOverText.enabled = true;
            gameOverText.text = "Game Over";
        }

        if (other.CompareTag("Pieza"))
        {
            Debug.Log("AGARRE UN PIEZA");
            cantPiza++;
            Debug.Log(cantPiza);

            switch (cantPiza)
            {
                case 1:
                    imagenUI1.gameObject.SetActive(true);
                    break;
                case 2:
                    imagenUI2.gameObject.SetActive(true);
                    break;
            }
        }
    }
    public void ChangeScene()
    {
        if (cantPiza == 3) 
        {
            SceneManager.LoadScene("ShootEmUpLevel1");
        }
        
    }
    public void Moving()
    {
        float mHorizontal = Input.GetAxis("Horizontal");
        float mVertical = Input.GetAxis("Vertical");

        transform.position += new Vector3(mHorizontal, 0, mVertical) * speed * Time.deltaTime;
    }
    private void Awake()
    {
        gameOverText.enabled = false;
        imagenUI1.gameObject.SetActive(false);
        imagenUI2.gameObject.SetActive(false);
    }
    void Update()
    {
        ChangeScene();
        Moving();
        //scoreText.text = cantPiza.ToString();
    }

}
