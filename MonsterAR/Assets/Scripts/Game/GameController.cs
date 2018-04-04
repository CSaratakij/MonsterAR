using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

namespace MonsterAR
{
    public class GameController : MonoBehaviour, ITrackableEventHandler
    {
        public static GameController instance;

        public static event Func OnGameInit;
        public static event Func OnGameStart;
        public static event Func OnGameOver;

        public delegate void Func();

        public bool IsGameStart { get { return isGameStart; } }
        public bool IsGameOver { get { return isGameOver; } }


        //Hacks
        [SerializeField]
        TrackableBehaviour trackableEvent;


        bool isInitStart;
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

            isGameOver = true;
            trackableEvent.RegisterTrackableEventHandler(this);
        }

        void _FireEvent_OnGameInit()
        {
            if (OnGameInit != null) {
                OnGameInit();
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

        public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
        {
            if (!isInitStart) { return; }
            if (isGameStart) { return; }
            if (TrackableBehaviour.Status.TRACKED == newStatus) {
                if (!isGameStart) {
                    isGameStart = true;
                    _FireEvent_OnGameStart();
                }
            }
        }

        public void GameStart()
        {
            if (isGameStart) { return; }
            isGameOver = false;
            isInitStart = true;
            _FireEvent_OnGameInit();
        }

        public void GameOver()
        {
            if (isGameOver) { return; }
            isGameOver = true;
            isGameStart = false;
            isInitStart = false;
            _FireEvent_OnGameOver();
        }
    }
}
