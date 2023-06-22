using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class StoneMoving : MonoBehaviour
{

    [SerializeField] private float movementSpeed;
    [SerializeField] private List<Vector3> targetPositions;
    
    private int targetIndex = 0;
    private bool isMoving = false;
    private Vector3 initialPosition;

     private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Astronaut"))
        {
            isMoving = true;

        }
    }
    
    private void Update()
    {
        if (isMoving)
        {
            initialPosition = transform.position;
            // Obtiene el objetivo actual
            Vector3 targetPosition = targetPositions[targetIndex];

            // Calcula el desplazamiento hacia el objetivo
            Vector3 displacement = (targetPosition - initialPosition).normalized * movementSpeed * Time.deltaTime;

            // Actualiza la posición del objeto
            transform.position += displacement;

            // Comprueba si ha alcanzado o pasado el objetivo
            if (Vector3.Distance(transform.position, targetPosition) <= displacement.magnitude)
            {
                // Llegó al objetivo, pasa al siguiente objetivo o vuelve al inicio
                targetIndex = (targetIndex + 1) % targetPositions.Count;
                initialPosition = targetPosition;

                // Llegó al objetivo, detiene el movimiento
                isMoving = false;
            }

        }

     }

}
