using UnityEngine;
using com.pacmaster.character;
using com.pacmaster.utils;

namespace com.pacmaster.menu
{
    public class MainMenuController : MonoBehaviour
    {
        private enum MenuWindows
        {
            Defualt,
            TitleScreen,
            MainMenu,
            CharacterSlection
        }

        [SerializeField]
        private TitleScreenController titleScreen;
        [SerializeField]
        private MainMenuScreenController mainMenu;
        [SerializeField]
        private CharacterSelectionScreenController characterSelection;
        [SerializeField]
        private LevelTransition levelTransition;

        private CharacterDataController _characterData;

        private MenuWindows _currentWindow;

        private MenuWindows _previousWindow;

        private MenuWindows CurrentWindow
        {
            get { return _currentWindow; }
            set 
            { 
                if (!_currentWindow.Equals(value))
                {
                    _previousWindow = _currentWindow;
                    _currentWindow = value;
                    Debug.Log("You are currently in " + value.ToString());
                    MakeWindowTransition();
                }
            }
        }


        // Start is called before the first frame update
        private void Start()
        {
            _characterData = FindObjectOfType<CharacterDataController>();
            if (!titleScreen) Debug.LogWarning("There is no titleScreen");
            if (!mainMenu)
            {
                Debug.LogWarning("There is no mainMenu");
            }
            else
            {
                mainMenu.SubscribeExitButton(Application.Quit);
                mainMenu.SubscribeSinglePlayerButton(GoToCharacterSelection);
            }
            if (!characterSelection)
            {
                Debug.LogWarning("There is no characterSelection");
            }
            else
            {
                characterSelection.SubscribePacmanButton(() => LoadSinglePlayerLevelWithCharacter(CharacterDataController.PacmanCharacters.Pacman));
                characterSelection.SubscribeBlinkyButton(() => LoadSinglePlayerLevelWithCharacter(CharacterDataController.PacmanCharacters.Blinky));
                characterSelection.SubscribeClydeButton(() => LoadSinglePlayerLevelWithCharacter(CharacterDataController.PacmanCharacters.Clyde));
                characterSelection.SubscribePinkyButton(() => LoadSinglePlayerLevelWithCharacter(CharacterDataController.PacmanCharacters.Pinky));
                characterSelection.SubscribeInkyButton(() => LoadSinglePlayerLevelWithCharacter(CharacterDataController.PacmanCharacters.Inky));
                characterSelection.SubscribeBackButton(GoBack);
            }

            CurrentWindow = MenuWindows.TitleScreen;
        }

        private void Update()
        {
            if (CurrentWindow.Equals(MenuWindows.TitleScreen) && Input.anyKeyDown)
            {
                GoToMainMenu();
            } 
            else if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (CurrentWindow.Equals(MenuWindows.MainMenu))
                {
                    GoToTitleScreen();
                } 
                else if (CurrentWindow.Equals(MenuWindows.CharacterSlection))
                {
                    GoToMainMenu();
                }
            }
        }

        private void GoBack()
        {
            switch (_previousWindow)
            {
                case MenuWindows.MainMenu:
                    GoToMainMenu();
                    break;
            }
        }

        private void LoadSinglePlayerLevelWithCharacter(CharacterDataController.PacmanCharacters playerCharacter)
        {
            levelTransition.StartLevelTransition(_characterData.SetCharacter(playerCharacter), 1);
        }

        private void MakeWindowTransition()
        {
            switch (CurrentWindow)
            {
                case MenuWindows.TitleScreen:
                    HandleTitleScreenActivation();
                    break;
                case MenuWindows.MainMenu:
                    HandleMainMenuScreenActivation();
                    break;
                case MenuWindows.CharacterSlection:
                    HandleCharacterSelectionScreenActivation();
                    break;
            }
        }

        private void GoToCharacterSelection()
        {
            switch (CurrentWindow)
            {
                case MenuWindows.MainMenu:
                    HandleMainMenuCancel();
                    break;
            }
            CurrentWindow = MenuWindows.CharacterSlection;
        }

        private void GoToMainMenu()
        {
            switch (CurrentWindow)
            {
                case MenuWindows.TitleScreen:
                    HandleTitleScreenCancel();
                    break;
                case MenuWindows.CharacterSlection:
                    HandleCharacterSelectionScreenCancel();
                    break;
            }
            CurrentWindow = MenuWindows.MainMenu;
        }

        private void GoToTitleScreen()
        {
            switch (CurrentWindow)
            {
                case MenuWindows.MainMenu:
                    HandleMainMenuCancel();
                    break;
            }
            CurrentWindow = MenuWindows.TitleScreen;
        }

        private void HandleTitleScreenCancel()
        {
            titleScreen.DisableTitleScreen();
        }

        private void HandleTitleScreenActivation()
        {
            titleScreen.ActivateTitleScreen();
        }

        private void HandleMainMenuCancel()
        {
            mainMenu.DisableMainMenuScreen();
        }

        private void HandleMainMenuScreenActivation()
        {
            mainMenu.ActivateMainMenuScreen();
        }

        private void HandleCharacterSelectionScreenCancel()
        {
            characterSelection.DisableScharacterSelectionScreen();
        }

        private void HandleCharacterSelectionScreenActivation()
        {
            characterSelection.ActivateScharacterSelectionScreen();
        }

    }
}
