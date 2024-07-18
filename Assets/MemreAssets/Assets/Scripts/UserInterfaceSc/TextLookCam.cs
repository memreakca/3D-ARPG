using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextLookCam : MonoBehaviour
{
    private Transform mainCamTrns;

    private void Start()
    {
        Cinemachine.CinemachineBrain cinemachineBrain = FindObjectOfType<Cinemachine.CinemachineBrain>();
        mainCamTrns = cinemachineBrain.transform;
    }

    private void Update()
    {
        //as
        transform.LookAt(mainCamTrns);
        transform.Rotate(0, 180, 0);
    }
}
