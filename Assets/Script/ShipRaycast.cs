using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipRaycast : MonoBehaviour
{
    [SerializeField] private Transform PuntoDeMira;
    [SerializeField] private float maxDistance;
    [SerializeField] private float sphereRadius;
    [SerializeField] private LayerMask reycastLayer;

    public bool reycasOk;
    private bool SeeShoot()
    {
        bool isSee = Physics.SphereCast(PuntoDeMira.position, sphereRadius, PuntoDeMira.forward, out RaycastHit ShepreHit, maxDistance, reycastLayer);
        
        if (isSee)
        {
            reycasOk = true;
        }
        else 
        {
            reycasOk = false; 
        }
        return reycasOk;
    }
    void Update()
    {
        SeeShoot();
        //Debug.Log($"¿De verdad esta chocando? {reycasOk}");
    }
}
