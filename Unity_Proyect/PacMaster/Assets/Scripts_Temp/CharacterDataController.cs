using UnityEngine;

namespace com.pacmaster.character
{
    public class CharacterDataController : MonoBehaviour
    {
        public enum PacmanCharacters
        {
            None,
            Pacman,
            Blinky,
            Clyde,
            Pinky,
            Inky
        }

        public PacmanCharacters selectedCharacter;
        public Color color;

        public Color SetCharacter(PacmanCharacters character)
        {
            selectedCharacter = character;
            switch (character)
            {
                case PacmanCharacters.Pacman:
                    color = Color.yellow;
                    break;
                case PacmanCharacters.Blinky:
                    color = Color.red;
                    break;
                case PacmanCharacters.Clyde:
                    color = new Color(1f, 0.5f, 0f);
                    break;
                case PacmanCharacters.Pinky:
                    color = new Color(1f, 0f, 0.6f);
                    break;
                case PacmanCharacters.Inky:
                    color = Color.cyan;
                    break;
            }
            return color;
        }

        private void Awake()
        {
            CharacterDataController[] datas = FindObjectsOfType<CharacterDataController>();

            if (datas.Length > 1) Destroy(gameObject);

            DontDestroyOnLoad(gameObject);
        }
    }
}
