using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MonsterAR
{
    public class UILogic : MonoBehaviour
    {
        //Hacks
        [SerializeField]
        GameUIController gameUIController;


        public void StartGame()
        {
            if (!GameController.instance) { return; }
            GameController.instance.GameStart();
        }

        public void ExitGame()
        {
            Application.Quit();
        }

        public void BackToMainMenu()
        {
            if (!gameUIController) { return; }
            gameUIController.ShowOnly(GameUIController.ViewPanel.MainMenu);
        }
    }
}
