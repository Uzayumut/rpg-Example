using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace RPG.Movement
{
    public class Mover : MonoBehaviour
    {
        // Start is called before the first frame update
        [SerializeField] Transform target;

        NavMeshAgent navMeshAgent;
        private void Start()
        {
            navMeshAgent= GetComponent<NavMeshAgent>();
            navMeshAgent.isStopped = false;
        }

        // Update is called once per frame
        void Update()
        {
            //navMeshAgent.isStopped = false;
            UpdateAnimator();

        }


        public void MoveTo(Vector3 destination)
        {
            navMeshAgent.destination = destination;
            navMeshAgent.isStopped = false;
        }
        public void Stop()
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
