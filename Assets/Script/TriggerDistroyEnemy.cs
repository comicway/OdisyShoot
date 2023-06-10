using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDistroyEnemy : MonoBehaviour
{
    
    [SerializeField] private GameObject efect;
    [SerializeField] private float destroyTime;
    public void InstanciarEfecto()
    {
        Instantiate(efect, transform.position, transform.rotation);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bala"))
        {
            Destroy(gameObject, destroyTime);
            InstanciarEfecto();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
