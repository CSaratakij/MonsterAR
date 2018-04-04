using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MonsterAR
{
    public class PlayerController : MonoBehaviour
    {
        const float ATTACK_RANGE = 0.6f;

        //Hacks
        [SerializeField]
        Camera camera;

        [SerializeField]
        MonsterController monster;

        [SerializeField]
        LayerMask monsterMask;


        bool isAttacked;


        void Awake()
        {
            camera = GetComponent<Camera>();
        }

        void FixedUpdate()
        {
            var isNearMonster = Vector3.Distance(monster.gameObject.transform.position, transform.position) <= ATTACK_RANGE;
            if (isNearMonster && isAttacked) {
                monster.Health.Remove(20);
            }

            isAttacked = false;
        }

        public void Attack()
        {
            isAttacked = true;
        }
    }
}
