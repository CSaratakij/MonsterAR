using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MonsterAR
{
    public class GameController : MonoBehaviour
    {
        public static GameController instance;

        public static event Func OnGameStart;
        public static event Func OnGameOver;

        public delegate void Func();


        bool isGameStart;
        bool isGameOver;


        void Awake()
        {
            _Initialize();
        }

        void _Initialize()
        {
            if (instance == null) {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else {
                Destroy(gameObject);
            }
        }

        void _FireEvent_OnGameStart()
        {
            if (OnGameStart != null) {
                OnGameStart();
            }
        }

        void _FireEvent_OnGameOver()
        {
            if (OnGameOver != null) {
                OnGameOver();
            }
        }
    }
}
