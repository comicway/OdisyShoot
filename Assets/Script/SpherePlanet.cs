using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpherePlanet : MonoBehaviour
{

    public static SpherePlanet planeta;
    [SerializeField] private float fuerzaGravity; 
    public List<Rigidbody> objetos;
    //Para  rotar al planeta
    [SerializeField] private float rotationSpeed;
    private Transform sphereTransform;

    void Awake()
    {
        planeta = this;
    }

    private void Start()
    {
        sphereTransform = GetComponent<Transform>();
    }
    private void FixedUpdate()
    {
        foreach (Rigidbody objeto in objetos)
        {
            Vector3 directionGravity = (objeto.transform.position - transform.position).normalized;

            Vector3 directionObjeto = objeto.transform.up;

            objeto.AddForce(directionGravity * fuerzaGravity * Time.fixedDeltaTime);

            Quaternion nRotacion = Quaternion.FromToRotation (directionObjeto, directionGravity)*objeto.transform.rotation;

            objeto.transform.rotation = Quaternion.Slerp (objeto.transform.rotation, nRotacion, 50 * Time.fixedDeltaTime);
        } 
    }
    private void Update()
    {
        sphereTransform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }
}
