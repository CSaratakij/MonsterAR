using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MonsterAR
{
    public class PlayerController : MonoBehaviour
    {
        const string HEALTH_TEMPLATE = "Player : {0} / {1}";
        const float ATTACK_RANGE = 0.3f;

        //Hacks
        [SerializeField]
        Transform back;

        [SerializeField]
        Text txtHealth;

        [SerializeField]
        MonsterController monster;

        [SerializeField]
        LayerMask monsterMask;


        Status health;
        public Status Health { get { return health; } }

        bool isAttacked;


        void Awake()
        {
            health = new Status(200, 200);
        }

        void Update()
        {
            txtHealth.text = string.Format(HEALTH_TEMPLATE, health.Current, health.Maximum);
        }

        void FixedUpdate()
        {
            var isNearWeakPoint = Vector3.Distance(back.position, transform.position) <= ATTACK_RANGE;
            var isFront = (transform.position - back.position).z > 0.0f;

            if (!isFront && isNearWeakPoint && isAttacked) {
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
