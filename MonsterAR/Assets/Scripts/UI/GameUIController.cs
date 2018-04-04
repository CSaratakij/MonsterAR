using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

namespace MonsterAR
{
    public class GameUIController : MonoBehaviour, ITrackableEventHandler
    {
        const string WARNING_TEXT_TEMPLATE = "Game Over in : {0}";

        //Hacks
        [SerializeField]
        Timer timer;

        //Hacks
        [SerializeField]
        Text lblWarning;

        [SerializeField]
        GameObject[] panels;

        //Hacks
        [SerializeField]
        TrackableBehaviour trackableEvent;

        public enum ViewPanel {
            MainMenu,
            CheckTracker,
            GameUI,
            MissingMonster,
            GameOver
        }

        void Awake()
        {
            _Subscribe_Events();
        }

        void OnDestroy()
        {
            _Unsubscribe_Events();
        }

        void _Subscribe_Events()
        {
            GameController.OnGameInit += _OnGameInit;
            GameController.OnGameStart += _OnGameStart;
            GameController.OnGameOver += _OnGameOver;

            //Hacks
            trackableEvent.RegisterTrackableEventHandler(this);
        }

        void _Unsubscribe_Events()
        {
            GameController.OnGameInit -= _OnGameInit;
            GameController.OnGameStart -= _OnGameStart;
            GameController.OnGameOver -= _OnGameOver;
        }

        void _OnGameInit()
        {
            ShowOnly(ViewPanel.CheckTracker);
        }

        void _OnGameStart()
        {
            ShowOnly(ViewPanel.GameUI);
        }

        void _OnGameOver()
        {
            ShowOnly(ViewPanel.GameOver);
        }

        void _HideAll()
        {
            foreach (GameObject obj in panels) {
                obj.SetActive(false);
            }
        }

        public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
        {
            if (!GameController.instance) { return; }
            if (GameController.instance.IsGameOver) { return; }
            if (!GameController.instance.IsGameStart) { return; }

            if (TrackableBehaviour.Status.TRACKED == newStatus) {
                ShowOnly(ViewPanel.GameUI);
            }
            else if (TrackableBehaviour.Status.NOT_FOUND == newStatus) {
                ShowOnly(ViewPanel.MissingMonster);

            }
        }

        public void Hide(ViewPanel panel)
        {
            panels[(int)panel].SetActive(false);
        }

        public void Show(ViewPanel panel)
        {
            panels[(int)panel].SetActive(true);
        }

        public void ShowOnly(ViewPanel panel)
        {
            _HideAll();
            Show(panel);
        }
    }
}
