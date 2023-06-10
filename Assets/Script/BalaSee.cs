using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BalaSee : PlayBullet
{
    [SerializeField] private float speed;
    [SerializeField] private float tiempoInicial;
    private float tiempoActual;
    [SerializeField] private GameObject efect;
    //public UnityEvent QuieresInstanciar;
    public void InstanciarEfecto()
    {
        Instantiate(efect, transform.position, transform.rotation);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            InstanciarEfecto();
            //QuieresInstanciar?.Invoke();
        }
    }

    private void Awake()
    {
        tiempoActual = tiempoInicial;
    }
    // Update is called once per frame
    void Update()
    {
        transform.position += speed * Time.deltaTime * transform.forward;

        tiempoActual -= Time.deltaTime;

        DestroyBullet(tiempoActual);

    }
}
