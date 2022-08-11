using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace com.pacmaster.menu
{
    public class SettingsScreenController : MonoBehaviour
    {
        [SerializeField]
        private Animator settingsScreenAnimator;
        [SerializeField]
        private Button backButton;


        // Start is called before the first frame update
        void Start()
        {
            if (!settingsScreenAnimator) Debug.LogWarning("There is no Animator!");
        }

        public void ActivateSettingsScreen()
        {
            settingsScreenAnimator.gameObject.SetActive(true);
            if (settingsScreenAnimator) settingsScreenAnimator.SetTrigger("FadeIn");
        }

        public void DisableSettingsScreen()
        {
            if (settingsScreenAnimator) settingsScreenAnimator.SetTrigger("FadeOut");
        }

        public void SubscribeBackButton(UnityAction action)
        {
            backButton.onClick.AddListener(action);
        }
    }

}
