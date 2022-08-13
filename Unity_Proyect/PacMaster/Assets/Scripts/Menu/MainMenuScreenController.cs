using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace com.pacmaster.menu
{
    public class MainMenuScreenController : MonoBehaviour
    {

        [SerializeField]
        private Animator mainMenuScreenAnimator;
        [SerializeField]
        private Button singlePlayerButton;
        [SerializeField]
        private Button multiPlayerButton;
        [SerializeField]
        private Button settingsButton;
        [SerializeField]
        private Button creditsButton;
        [SerializeField]
        private Button exitButton;


        // Start is called before the first frame update
        void Start()
        {
            if (!mainMenuScreenAnimator) Debug.LogWarning("There is no Animator!");
        }

        public void ActivateMainMenuScreen()
        {
            mainMenuScreenAnimator.gameObject.SetActive(true);
            if (mainMenuScreenAnimator) mainMenuScreenAnimator.SetTrigger("FadeIn");
        }

        public void DisableMainMenuScreen()
        {
            if (mainMenuScreenAnimator) mainMenuScreenAnimator.SetTrigger("FadeOut");
        }

        public void SubscribeSinglePlayerButton(UnityAction action)
        {
            singlePlayerButton.onClick.AddListener(action);
        }

        public void SubscribeMultiPlayerButton(UnityAction action)
        {
            multiPlayerButton.onClick.AddListener(action);
        }

        public void SubscribeSettingsButton(UnityAction action)
        {
            settingsButton.onClick.AddListener(action);
        }

        public void SubscribeCreditsButton(UnityAction action)
        {
            creditsButton.onClick.AddListener(action);
        }

        public void SubscribeExitButton(UnityAction action)
        {
            exitButton.onClick.AddListener(action);
        }
    }
}


