using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {

    public Interactable focus;

    public LayerMask movementMask;
    Camera cam;
    PlayerMotor motor;
	// Use this for initialization
	void Start () {
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray,out hit,100,movementMask))
            {
                motor.MoveToPoint(hit.point);
                RemoveFocus();
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                Interactable i  = hit.collider.GetComponent<Interactable>();
                if(i != null)
                {
                    SetFocus(i);
                }
            }
        }
    }
    void SetFocus(Interactable f)
    {
        if(f!=focus)
        {
            if(focus != null)
                focus.onDefocus();
            focus = f;
            motor.FollowTarget(f);
        }
        f.onFocus(transform);
    }
    void RemoveFocus()
    {
        if(focus!=null)
            focus.onDefocus();
        focus = null;
        motor.StopFollowimgTarget();
    }
}
