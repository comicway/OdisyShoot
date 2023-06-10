using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDistroyPiezas : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Astronaut"))
        {
            Destroy(gameObject);
            
        }
    }
}
