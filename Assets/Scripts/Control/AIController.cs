using RPG.Combat;
using RPG.Core;
using RPG.Movement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Control
{
    public class AIController : MonoBehaviour
    {
        [SerializeField] float chaseDistance = 5f;
        [SerializeField] float suspicionTime = 3f;

        Fighter fighter;
        GameObject player;
        Mover mover;
        Health health;

        Vector3 guardPosition;
        float timeSinceLastSawPlayer=Mathf.Infinity;
        private void Start()
        {
            fighter= GetComponent<Fighter>();
            health= GetComponent<Health>();
            mover= GetComponent<Mover>();
            player = GameObject.FindWithTag("Player");
            guardPosition= transform.position;
        }
        private void Update()
        {
            if(health.IsDead()) return;
           
            if (InAttackRangeOfPlayer() && fighter.CanAttack(player))
            {
                timeSinceLastSawPlayer = 0;
                AttackBehaviour();
            }
            else if(timeSinceLastSawPlayer<suspicionTime)
            {
                SuspicionBehaviour();
            }
            else
            {
                GuardBehaviour();

            }
            timeSinceLastSawPlayer += Time.deltaTime;

            void SuspicionBehaviour()
            {
                GetComponent<ActionScheduler>().CancelCurrentAction();
            }

            void GuardBehaviour()
            {
                mover.StartMoveAction(guardPosition);
            }

            void AttackBehaviour()
            {
                fighter.Attack(player);
            }
        }
        private bool InAttackRangeOfPlayer()
        {
            float distanceToPlayer= Vector3.Distance(player.transform.position, transform.position);
            return distanceToPlayer < chaseDistance;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, chaseDistance);
        }
    }
}

