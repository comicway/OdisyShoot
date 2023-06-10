using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyBasic : PlayEnemies
{
    //Isntancia bala
    [SerializeField] private Transform PuntoDeDisparo;
    private float tiempoActual;
    [SerializeField] private BalaEnemyBasic disparoBala;
    public float frecuenciaDeDisparo;
    //Bala te veo
    [SerializeField] private BalaSee balaSee;
    [SerializeField] private float frecuenciaSeeBala;
    private float tiempoSeeBala;
    //This is a Reycast
    [SerializeField] private float maxDistance;
    [SerializeField] private float sphereRadius;
    [SerializeField] private LayerMask reycastLayer;
   

    private void SeeAndShoot()
    {
        //bool isHitting =  Physics.Raycast(PuntoDeDisparo.position, PuntoDeDisparo.forward,maxDistance, reycastLayer);

        bool isHitting = Physics.SphereCast(PuntoDeDisparo.position, sphereRadius, PuntoDeDisparo.forward, out RaycastHit ShepreHit, maxDistance, reycastLayer);


        if (isHitting == true)
        {
            
            Instantiate(balaSee, PuntoDeDisparo.position, PuntoDeDisparo.rotation);
          
           //tiempoActual = frecuenciaDeDisparo;
        }

        //Debug.Log($"¿De verdad esta chocando? {isHitting}");
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        //Gizmos.DrawLine(PuntoDeDisparo.position, PuntoDeDisparo.position + PuntoDeDisparo.forward * maxDistance);

        Gizmos.DrawWireSphere(PuntoDeDisparo.position, sphereRadius);
    }

    private void Awake()
    {
        tiempoActual = frecuenciaDeDisparo;
        tiempoSeeBala = frecuenciaSeeBala;
    }

    // Update is called once per frame
    void Update()
    {

        //InstanciarBalas();
        MovingForward();

        tiempoActual -= Time.deltaTime;

        if (tiempoActual <= 0)
        {

            Instantiate(disparoBala, PuntoDeDisparo.position, PuntoDeDisparo.rotation);

            tiempoActual = frecuenciaDeDisparo;
        }

        tiempoSeeBala -= Time.deltaTime;

        if (tiempoSeeBala <= 0)
        {

            SeeAndShoot();

            tiempoSeeBala = frecuenciaSeeBala;
            
        }
    }
}
