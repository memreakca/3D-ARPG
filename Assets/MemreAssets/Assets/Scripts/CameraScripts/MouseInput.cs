using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInput : MonoBehaviour
{

    [HideInInspector]    
    public Vector3 mousePosition;

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, float.MaxValue))
        {
            mousePosition = hit.point;
            if(Input.GetMouseButtonDown(0)) { Debug.Log(mousePosition); }
            
        }
    }
}
