using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace com.pacmaster.menu
{
    public class CreditsScreenController : MonoBehaviour
    {
        [SerializeField]
        private Animator creditsScreenAnimator;
        [SerializeField]
        private Button backButton;


        // Start is called before the first frame update
        void Start()
        {
            if (!creditsScreenAnimator) Debug.LogWarning("There is no Animator!");
        }

        public void ActivateCreditsScreen()
        {
            creditsScreenAnimator.gameObject.SetActive(true);
            if (creditsScreenAnimator) creditsScreenAnimator.SetTrigger("FadeIn");
        }

        public void DisableCreditsScreen()
        {
            if (creditsScreenAnimator) creditsScreenAnimator.SetTrigger("FadeOut");
        }

        public void SubscribeBackButton(UnityAction action)
        {
            backButton.onClick.AddListener(action);
        }
    }

}
