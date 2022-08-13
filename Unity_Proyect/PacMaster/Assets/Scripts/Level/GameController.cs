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

        [Header("Events")]
        [SerializeField]
        private GameEvent smallPellet;
        [SerializeField]
        private int pelletSubstraction = 10;

        // Start is called before the first frame update
        void Start()
        {
            if (!timer) Debug.LogWarning("There is no timer text set");
            if (!smallPellet)
            {
                Debug.LogWarning("There is no smallPellet event");
            }
            else
            {
                smallPellet.RegisterListener(PacmanAtePellet);
            }
        }

        private void FixedUpdate()
        {
            if (timerSeconds > 0)
            {
                timerSeconds -= Time.deltaTime;
                timer.text = GetTimeText();

                if (timerSeconds <= 0)
                {
                    EndGame();
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


        private void EndGame()
        {
            Debug.Log("GAME FINISHED AND FOKING PACMAN WINNS M8");
        }

    }
}
