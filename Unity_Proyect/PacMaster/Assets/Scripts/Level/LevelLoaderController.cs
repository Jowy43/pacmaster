using UnityEngine;
using System.Collections.Generic;
using com.pacmaster.character;
using com.pacmaster.utils;

namespace com.pacmaster.level
{
    public class LevelLoaderController : MonoBehaviour
    {

        private CharacterDataController dataController;
        private CharacterDataController.PacmanCharacters character;
        private Color characterColor;

        [SerializeField]
        private LevelTransition transition;
        [SerializeField]
        private List<CharacterController> characterControllers;

        private void Awake()
        {
            dataController = FindObjectOfType<CharacterDataController>();
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
            transition.SetImageColor(characterColor);
        }

    }
}
