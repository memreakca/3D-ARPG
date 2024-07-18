using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageLookCam : MonoBehaviour
{

    private Transform mainCamTrns;

    private void Start()
    {
        Cinemachine.CinemachineBrain cinemachineBrain = FindObjectOfType<Cinemachine.CinemachineBrain>();
        mainCamTrns = cinemachineBrain.transform;
    }

    private void Update()
    {
        transform.LookAt(mainCamTrns);
        
    }
}
