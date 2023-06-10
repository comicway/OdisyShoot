using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
    [SerializeField] private GameObject camara01, camara02;
    // Start is called before the first frame update

    private void AlternateCameras()
    {
        camara01.SetActive(!camara01.activeSelf);
        camara02.SetActive(!camara02.activeSelf);
    }
    void Start()
    {
        camara01.SetActive(true);
        camara02.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AlternateCameras();
        }
    }
}
