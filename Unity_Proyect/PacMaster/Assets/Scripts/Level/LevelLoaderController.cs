using UnityEngine;
using com.pacmaster.character;
using com.pacmaster.utils;
using com.pacmaster.events;

namespace com.pacmaster.level
{
    public class LevelLoaderController : MonoBehaviour
    {

        private CharacterDataController dataController;
        private CharacterDataController.PacmanCharacters character;
        private Color characterColor;

        [SerializeField]
        private LevelTransition transition;
        [Header("Player Controllers")]
        [SerializeField]
        private PacmanPlayerController pacmanController;
        [SerializeField]
        private GhostPlayerController blinkyController;
        [SerializeField]
        private GhostPlayerController ClydeController;
        [SerializeField]
        private GhostPlayerController InkyController;
        [SerializeField]
        private GhostPlayerController PinkyController;
        [Header("Events")]
        [SerializeField]
        private GameEvent startGame;
        [SerializeField]
        private GameEvent pacmanWins;
        [SerializeField]
        private GameEvent ghostWins;

        private void Awake()
        {
            dataController = FindObjectOfType<CharacterDataController>();
            if (!pacmanWins)
            {
                Debug.LogWarning("There is no event for pacmanwins atached");
            }
            else
            {
                pacmanWins.RegisterListener(EndGame);
            }
            if (!ghostWins)
            {
                Debug.LogWarning("There is no event for ghostWins atached");
            }
            else
            {
                ghostWins.RegisterListener(EndGame);
            }
            if (!startGame)
            {
                Debug.LogWarning("There is no event for startGame atached");
            }
            else
            {
                startGame.RegisterListener(SetupPlayer);
            }
            if (dataController)
            {
                character = dataController.selectedCharacter;
                characterColor = dataController.color;
            }
            else
            {
                character = CharacterDataController.PacmanCharacters.Pacman;
                characterColor = Color.yellow;
            }
            Cursor.visible = false;
            transition.SetImageColor(characterColor);
        }

        private void SetupPlayer()
        {
            switch (character)
            {
                case CharacterDataController.PacmanCharacters.Pacman:
                    pacmanController.enabled = true;
                    break;
                case CharacterDataController.PacmanCharacters.Blinky:
                    blinkyController.enabled = true;
                    break;
                case CharacterDataController.PacmanCharacters.Clyde:
                    ClydeController.enabled = true;
                    break;
                case CharacterDataController.PacmanCharacters.Pinky:
                    PinkyController.enabled = true;
                    break;
                case CharacterDataController.PacmanCharacters.Inky:
                    InkyController.enabled = true;
                    break;
            }
        }

        private void EndGame()
        {
            transition.StartLevelTransition(characterColor, 0);
        }

    }
}
