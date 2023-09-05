using RPG.Combat;
using RPG.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Control
{
    public class AIController : MonoBehaviour
    {
        [SerializeField] float chaseDistance = 5f;

        Fighter fighter;
        GameObject player;
        Health health;
        private void Start()
        {
            fighter= GetComponent<Fighter>();
            health= GetComponent<Health>();
            player = GameObject.FindWithTag("Player");
        }
        private void Update()
        {
            if(health.IsDead()) return;
           
            if (InAttackRangeOfPlayer() && fighter.CanAttack(player)) 
            {
                fighter.Attack(player);
            }
            else
            {
                fighter.Cancel();
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
