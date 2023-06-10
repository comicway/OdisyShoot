using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessingControler : MonoBehaviour
{

    [SerializeField] private Volume postProcess;

    private Vignette vignetteEffect;

    //private void ChangeIntensy()
    //{
    //    if (postProcess.sharedProfile.TryGet(out Vignette vignetteEffect))
    //    {
    //        vignetteEffect.intensity.value = 0.79f;
    //    }
        
    //}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //ChangeIntensy();
        }
    }
}
