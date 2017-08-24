using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactable : MonoBehaviour {

    public float radius = 3f;
    public Transform interactionTransform;
    bool isFocus = false;
    Transform player;
    bool hasInteracted = false;

    public virtual void interact()
    {
        Debug.Log("Interacting With " + name);
    }
    private void Update()
    {
        if(isFocus && hasInteracted == false)
        {
            float distance = Vector3.Distance(player.position, interactionTransform.position);
            if(distance <= radius)
            {
                hasInteracted = true;
                interact();
            }
        }
    }
    public void onFocus(Transform playerTrans)
    {
        isFocus = true;
        player = playerTrans;
        hasInteracted = false;
    }
    public void onDefocus()
    {
        isFocus = false;
        player = null;
        hasInteracted = false;
    }
    private void OnDrawGizmosSelected()
    {
        if (interactionTransform == null)
            interactionTransform = transform;
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }
}
