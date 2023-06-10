using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms.Impl;

[System.Serializable] public class Borde { 

    public float xMaximo, xMinimo, zMaximo, zMinimo;

}
public class Moving : MonoBehaviour
{
    //Player Data
    [SerializeField] private PlayerData playerData;
    //public float health;
    //[SerializeField] private float speed;
    public Borde bordeGame;
    //Para disparar
    [SerializeField] private BalaDisparada disparoBala;
    [SerializeField] private Transform PuntoDeDisparo;
    [SerializeField] private Transform PadresBalas;
    [SerializeField] private float frecuenciaDeDisparo;
    private float tiempoActual;
    //Para el efecto
    [SerializeField] private GameObject efect;
    //Para actulizar la vida en la UI 
    public TMP_Text vidaText;
    //GameOver Text
    public TMP_Text gameOverText;
    //Eventos C#
    public Action EventoVida;
    public Action EventoDisparo;
    public Action EventoUI;

    private void disparar()
    {

        Instantiate(disparoBala, PuntoDeDisparo.position, PuntoDeDisparo.rotation, PadresBalas);
        tiempoActual = frecuenciaDeDisparo;
        //Quien llama al evento
        Debug.Log("Me esta llamando EventoDisparo y lo escuha disparo");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BalaEnemy"))
        {
            playerData.health -= 1;
            //Debug.Log($"{other.name}");
        }
    }
    private void Death()
    {
        if (playerData.health <= 0)
        {
            Destroy(gameObject);
            InstanciarEfecto();
            gameOverText.enabled = true;
            gameOverText.text = "Game Over";
            playerData.health = playerData.originalHealth;
        }
    }
    public void InstanciarEfecto()
    {
        Instantiate(efect, transform.position, transform.rotation);
    }
    //Para actulizar la vida en la UI
    public void updateUI()
    {
        vidaText.text = playerData.health.ToString();
        Debug.Log("Me esta llamando EventoUI y lo escuha updateUI");
    }
    private void Awake()
    {
        gameOverText.enabled = false;
        EventoVida += Death;
        EventoDisparo += disparar;
        EventoUI += updateUI;
    }
    // Update is called once per frame
    void Update()
    {
        GameManager.Instance.Moving(playerData.speed);

        // Limites de la escena
        float ejeX = Mathf.Clamp(transform.position.x, bordeGame.xMinimo, bordeGame.xMaximo);
        float ejeZ = Mathf.Clamp(transform.position.z, bordeGame.zMinimo, bordeGame.zMaximo);
        transform.position = new Vector3(ejeX, transform.position.y,ejeZ);

        //Para disparar
        tiempoActual -= Time.deltaTime;

        if (Input.GetButtonDown("Fire1") && tiempoActual <= 0)
        {
           
           EventoDisparo?.Invoke();
            
        }

        //Death();

        //Para verificar si el evento es null
                
        EventoVida?.Invoke();
       
        EventoUI?.Invoke();
    }
}
