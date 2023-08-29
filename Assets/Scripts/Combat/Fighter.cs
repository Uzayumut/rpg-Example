using RPG.Movement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Combat
{
    public class Fighter : MonoBehaviour
    {
        [SerializeField] float weaponRange = 2f;
        Transform target;
        private void Update()
        {
            //bool isInRange = Vector3.Distance(transform.position, target.position) < weaponRange;
            //print(isInRange);
            if (target != null)
            {
                if(!(Vector3.Distance(transform.position, target.position) < weaponRange))
                {
                    GetComponent<Mover>().MoveTo(target.position);
                    print("test");
                }
                else
                {
                    GetComponent<Mover>().Stop();
                    //target = null;
                    print("durmasý gerek");
                }
                
            }
            else
            {
                //GetComponent<Mover>().MoveTo(target.position);
                print("test2");
            }
            
        }
        public void Attack(CombatTarget combatTarget)
        {
            target = combatTarget.transform;
        }
        
    }
}

