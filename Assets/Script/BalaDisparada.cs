using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaDisparada : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float tiempoInicial;
    private float tiempoActual;
    [SerializeField] private GameObject efect;
    //Para sumar score
    private ScoreManager score;

    public void InstanciarEfecto()
    {
        Instantiate(efect, transform.position, transform.rotation);
    }
    private void OnTriggerEnter(Collider other)
    {
      if (other.CompareTag("Enemy"))
       { 
        Destroy(gameObject);
        InstanciarEfecto();
        score.AddEnemyScore();
       }
    }
    private void Awake()
    {
        tiempoActual = tiempoInicial;
    }
    private void Start()
    {
        score = GameObject.FindObjectOfType<ScoreManager>();
    }
    // Update is called once per frame
    void Update()
    {
        transform.position += speed * Time.deltaTime * transform.forward;

        tiempoActual -= Time.deltaTime;

        if (tiempoActual <= 0)
        {
            Destroy(gameObject);
        } 
    }
}
