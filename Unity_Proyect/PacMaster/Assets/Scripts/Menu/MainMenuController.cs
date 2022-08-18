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
            CharacterSlection,
            Settings,
            Credits
        }

        [SerializeField]
        private TitleScreenController titleScreen;
        [SerializeField]
        private MainMenuScreenController mainMenu;
        [SerializeField]
        private CharacterSelectionScreenController characterSelection;
        [SerializeField]
        private SettingsScreenController settings;
        [SerializeField]
        private CreditsScreenController credits;
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
            Cursor.visible = true;
            _characterData = FindObjectOfType<CharacterDataController>();
            if (_characterData)
            {
                levelTransition.SetImageColor(_characterData.color);
            }
            else
            {
                Debug.LogWarning("No character data found in scene");
            }
            if (!titleScreen) Debug.LogWarning("There is no titleScreen");
            if (!mainMenu)
            {
                Debug.LogWarning("There is no mainMenu");
            }
            else
            {
                mainMenu.SubscribeExitButton(Application.Quit);
                mainMenu.SubscribeSinglePlayerButton(GoToCharacterSelection);
                mainMenu.SubscribeSettingsButton(GoToSettings);
                mainMenu.SubscribeCreditsButton(GoToCredits);
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
            if (!settings)
            {
                Debug.LogWarning("There is no settings");
            } 
            else
            {
                settings.SubscribeBackButton(GoToMainMenu);
            }
            if (!credits)
            {
                Debug.LogWarning("There is no credits");
            }
            else
            {
                credits.SubscribeBackButton(GoToMainMenu);
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
                else if (CurrentWindow.Equals(MenuWindows.CharacterSlection) || CurrentWindow.Equals(MenuWindows.Settings) || CurrentWindow.Equals(MenuWindows.Credits))
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
                case MenuWindows.Settings:
                    HandleSettingsScreenActivation();
                    break;
                case MenuWindows.Credits:
                    HandleCreditsScreenActivation();
                    break;
            }
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
                case MenuWindows.Settings:
                    HandleSettingsScreenCancel();
                    break;
                case MenuWindows.Credits:
                    HandleCreditsScreenCancel();
                    break;
            }
            CurrentWindow = MenuWindows.MainMenu;
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

        private void GoToSettings()
        {
            switch (CurrentWindow)
            {
                case MenuWindows.MainMenu:
                    HandleMainMenuCancel();
                    break;
            }
            CurrentWindow = MenuWindows.Settings;
        }

        private void GoToCredits()
        {
            switch (CurrentWindow)
            {
                case MenuWindows.MainMenu:
                    HandleMainMenuCancel();
                    break;
            }
            CurrentWindow = MenuWindows.Credits;
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

        private void HandleSettingsScreenCancel()
        {
            settings.DisableSettingsScreen();
        }

        private void HandleSettingsScreenActivation()
        {
            settings.ActivateSettingsScreen();
        }

        private void HandleCreditsScreenCancel()
        {
            credits.DisableCreditsScreen();
        }

        private void HandleCreditsScreenActivation()
        {
            credits.ActivateCreditsScreen();
        }

    }
}
