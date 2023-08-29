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

        // Update is called once per frame
        private void Start()
        {
            navMeshAgent= GetComponent<NavMeshAgent>();
        }
        void Update()
        {

            UpdateAnimator();

        }


        public void MoveTo(Vector3 destination)
        {
            navMeshAgent.destination = destination;
            navMeshAgent.isStopped = false;
        }

        private void UpdateAnimator()
        {
            Vector3 velocity = navMeshAgent.velocity;
            Vector3 localeVelocity = transform.InverseTransformDirection(velocity);
            float speed = localeVelocity.z;
            GetComponent<Animator>().SetFloat("forwardSpeed", speed);
        }
        public void Stop()
        {
            navMeshAgent.isStopped= true;
        }
    }
}
