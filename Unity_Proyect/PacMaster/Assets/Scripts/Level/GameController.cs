using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using com.pacmaster.events;

namespace com.pacmaster.level
{
    public class GameController : MonoBehaviour
    {

        [SerializeField]
        private float timerSeconds = 30 * 60;
        [SerializeField]
        private TextMeshProUGUI timer;
        [SerializeField]
        private TextMeshProUGUI victory;
        [SerializeField]
        private string pacmanVictoryText;
        [SerializeField]
        private string ghostVictoryText;

        [Header("Events")]
        [SerializeField]
        private GameEvent smallPellet;
        [SerializeField]
        private int pelletSubstraction = 10;

        [SerializeField]
        private GameEvent startGame;

        [SerializeField]
        private GameEvent pacmanWins;

        [SerializeField]
        private GameEvent ghostWins;

        private bool gameEnded = false;
        private bool gameStarted = false;

        // Start is called before the first frame update
        void Start()
        {
            if (!timer) Debug.LogWarning("There is no timer text set"); 
            if(!smallPellet)
            {
                Debug.LogWarning("There is no smallPellet event");
            }
            else
            {
                smallPellet.RegisterListener(PacmanAtePellet);
            }
            if (!startGame)
            {
                Debug.LogWarning("There is no startGame event");
            }
            else
            {
                startGame.RegisterListener(StartGame);
            }
            if (!pacmanWins)
            {
                Debug.LogWarning("There is no pacmanWins event");
            }
            else
            {
                pacmanWins.RegisterListener(PacmanWins);
            }
            if (!ghostWins)
            {
                Debug.LogWarning("There is no ghostWins event");
            }
            else
            {
                ghostWins.RegisterListener(GhostWins);
            }
        }

        private void FixedUpdate()
        {
            if (!gameEnded && gameStarted)
            {
                timerSeconds -= Time.deltaTime;
                timer.text = GetTimeText();

                if (timerSeconds <= 0)
                {
                    pacmanWins.ActivateEvent();
                }
            }
            
        }

        private string GetTimeText()
        {
            return timerSeconds > 0 ? Mathf.FloorToInt(timerSeconds / 60).ToString("d2") + ":" + Mathf.FloorToInt(timerSeconds % 60).ToString("d2") : "END";
        }

        private void PacmanAtePellet()
        {
            timerSeconds -= pelletSubstraction;
        }

        private void StartGame()
        {
            gameStarted = true;
        }

        private void PacmanWins()
        {
            gameEnded = true;
            victory.text = pacmanVictoryText;
        }

        private void GhostWins()
        {
            gameEnded = true;
            victory.text = ghostVictoryText;
        }

    }
}
