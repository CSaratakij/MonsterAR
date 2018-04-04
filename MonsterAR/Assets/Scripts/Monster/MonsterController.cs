using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MonsterAR
{
    public class MonsterController : MonoBehaviour
    {
        [SerializeField]
        MonsterState currentState;


        enum MonsterState
        {
            Idle,
            Aggressive,
            Tired
        }

        Status health;


        void Awake()
        {
            _Initialize();
        }

        void Update()
        {
            _MonsterState_Handler();
        }

        void FixedUpdate()
        {
            _Damage_Handler();
        }

        void _Initialize()
        {
            health = new Status(1000, 1000);
        }

        void _MonsterState_Handler()
        {
            switch (currentState) {
                case MonsterState.Idle:
                    _IdleState_Handler();
                    break;

                case MonsterState.Aggressive:
                    _AggressiveState_Handler();
                    break;

                case MonsterState.Tired:
                    _TiredState_Handler();
                    break;
            }

            //Hacks
            if (!GameController.instance) { return; }
            if (!GameController.instance.IsGameStart) { return; }

            if (health.Current <= 0 && !GameController.instance.IsGameOver) {
                GameController.instance.GameOver();
            }
        }

        void _IdleState_Handler()
        {

        }

        void _AggressiveState_Handler()
        {

        }

        void _TiredState_Handler()
        {

        }

        void _Damage_Handler()
        {

        }
    }
}
