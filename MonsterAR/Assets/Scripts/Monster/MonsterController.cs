using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MonsterAR
{
    public class MonsterController : MonoBehaviour
    {
        [SerializeField]
        MonsterState currentState;

        //Hacks
        [SerializeField]
        Slider healthBar;


        enum MonsterState
        {
            Idle,
            Aggressive,
            Tired
        }


        public Status Health { get { return health; } }
        Status health;


        void Awake()
        {
            _Initialize();
        }

        void Update()
        {
            _MonsterState_Handler();
            healthBar.value = health.Current;
        }

        void _Initialize()
        {
            health = new Status(1000, 1000);
        }

        void _Subscribe_Events()
        {
            GameController.OnGameInit += _OnGameInit;
        }

        void _Unsubscribe_Events()
        {
            GameController.OnGameInit -= _OnGameInit;
        }

        void _OnGameInit()
        {
            health.FullRestore();
            healthBar.value = health.Current;
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

                //Hacks
                health.FullRestore();
            }
        }

        void _IdleState_Handler()
        {

        }

        void _AggressiveState_Handler()
        {
            //shoot and rotate
        }

        void _TiredState_Handler()
        {
            //like idle
        }
    }
}
