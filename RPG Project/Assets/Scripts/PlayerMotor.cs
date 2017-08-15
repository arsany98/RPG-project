using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMotor : MonoBehaviour {

    Transform target;
    NavMeshAgent agent;
	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
	}

    private void Update()
    {
        if(target!= null)
        {
            agent.SetDestination(target.position);
            FaceTarget();
        }
    }
    public void MoveToPoint (Vector3 point) {
        agent.SetDestination(point);
	}

    public void FollowTarget(Interactable newTarget)
    {
        agent.stoppingDistance = newTarget.radius*0.8f;
        target = newTarget.interactionTransform;
        agent.updateRotation = false;
    }
    public void StopFollowimgTarget()
    {
        agent.stoppingDistance = 0f;
        target = null;
        agent.updateRotation = true;
    }
    void FaceTarget()
    {
        Vector3 dir = (target.position - transform.position).normalized;
        Quaternion look = Quaternion.LookRotation(new Vector3(dir.x,0f,dir.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, look, 5f * Time.deltaTime);

    }
}
