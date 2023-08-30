using RPG.Core;
using RPG.Movement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Combat
{
    public class Fighter : MonoBehaviour,IAction
    {
        [SerializeField] float weaponRange = 2f;
        Transform target;
        private void Update()
        {

            if (target == null) return;
            {
                if (!GetIsInRange())
                {
                    GetComponent<Mover>().MoveTo(target.position);
                    print("test");
                }
                else
                {
                    GetComponent<Mover>().Cancel();
                    //target = null;
                    print("durmasý gerek");
                }

            }

        }
        private bool GetIsInRange()
        {
            return Vector3.Distance(transform.position, target.position) < weaponRange;
        }
        public void Attack(CombatTarget combatTarget)
        {
            GetComponent<ActionScheduler>().StartAction(this);
            target = combatTarget.transform;
        }
        public void Cancel()
        {
            target = null;
        }
        
    }
}

