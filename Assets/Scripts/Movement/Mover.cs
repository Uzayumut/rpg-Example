using RPG.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace RPG.Movement
{
    public class Mover : MonoBehaviour,IAction
    {
        // Start is called before the first frame update
        [SerializeField] Transform target;

        NavMeshAgent navMeshAgent;
        Health health;
        private void Start()
        {
            health= GetComponent<Health>(); 
            navMeshAgent= GetComponent<NavMeshAgent>();
            navMeshAgent.isStopped = false;
        }
        // Update is called once per frame

        void Update()
        {
            navMeshAgent.enabled = !health.IsDead();
            //navMeshAgent.isStopped = false;
            UpdateAnimator();

        }
        public void StartMoveAction(Vector3 destination)
        {
            GetComponent<ActionScheduler>().StartAction(this);
            MoveTo(destination);
        }


        public void MoveTo(Vector3 destination)
        {
            navMeshAgent.destination = destination;
            navMeshAgent.isStopped = false;
        }
        public void Cancel()
        {
            navMeshAgent.isStopped= true;
        }


        private void UpdateAnimator()
        {
            Vector3 velocity = navMeshAgent.velocity;
            Vector3 localeVelocity = transform.InverseTransformDirection(velocity);
            float speed = localeVelocity.z;
            GetComponent<Animator>().SetFloat("forwardSpeed", speed);
        }

    }
}
