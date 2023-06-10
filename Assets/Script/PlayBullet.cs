using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBullet : Entity
{

    // DestroyBullet(tiempoActual);
    protected void DestroyBullet(float tiempoActual)
    {
        if (tiempoActual <= 0)
        {
            Destroy(gameObject);
            //Debug.Log("SI SE ESTAN DESTRUYENDO LAS BALAS");
        }

    }

}
