using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IInteractable
{
    public void Interact();
}
public class PlayerInteraction : MonoBehaviour
{
    public float InteractRange;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, InteractRange);

            foreach (Collider hitCollider in hitColliders)
            {
                IInteractable interactObj = hitCollider.GetComponent<IInteractable>();
                if (interactObj != null)
                {
                    interactObj.Interact();
                }
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, InteractRange);
       
    }
}
