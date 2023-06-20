using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class StoneMoving : MonoBehaviour
{

    private Vector3 targetPosition01 = new Vector3(-299.9f, -1f, -301.6f);
    private float movementSpeed = 5f;

    private bool isMoving = false;
    private Vector3 initialPosition;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Astronaut") && !isMoving)
        {

            Moving();

            //transform.position = targetPosition01;
            //Debug.Log("Esta haciendo collider");
        }
    }
    public void Moving()
    {
        if (isMoving)
        {
            initialPosition = transform.position;
            // Calcula el desplazamiento hacia el objetivo
            Vector3 displacement = (targetPosition01 - initialPosition).normalized * movementSpeed * Time.deltaTime;

            // Actualiza la posición del objeto
            transform.position += displacement;

            // Comprueba si ha alcanzado o pasado el objetivo
            if (Vector3.Distance(transform.position, targetPosition01) <= displacement.magnitude)
            {
                // Llegó al objetivo, detiene el movimiento
                isMoving = false;
            }
        }

    }
    private void Update()
    {
        
        
    }

}
