using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace com.pacmaster.menu
{

    public class CharacterSelectionScreenController : MonoBehaviour
    {
        [SerializeField]
        private Animator characterSelectionScreenAnimator;
        [SerializeField]
        private Button pacmanButton;
        [SerializeField]
        private Button blinkyButton;
        [SerializeField]
        private Button clydeButton;
        [SerializeField]
        private Button pinkyButton;
        [SerializeField]
        private Button inkyButton;


        // Start is called before the first frame update
        void Start()
        {
            if (!characterSelectionScreenAnimator) Debug.LogWarning("There is no Animator!");
        }

        public void ActivateScharacterSelectionScreen()
        {
            characterSelectionScreenAnimator.gameObject.SetActive(true);
            if (characterSelectionScreenAnimator) characterSelectionScreenAnimator.SetTrigger("FadeIn");
        }

        public void DisableScharacterSelectionScreen()
        {
            if (characterSelectionScreenAnimator) characterSelectionScreenAnimator.SetTrigger("FadeOut");
        }

        public void SubscribePacmanButton(UnityAction action)
        {
            pacmanButton.onClick.AddListener(action);
        }

        public void SubscribeBlinkyButton(UnityAction action)
        {
            blinkyButton.onClick.AddListener(action);
        }

        public void SubscribeClydeButton(UnityAction action)
        {
            clydeButton.onClick.AddListener(action);
        }

        public void SubscribePinkyButton(UnityAction action)
        {
            pinkyButton.onClick.AddListener(action);
        }

        public void SubscribeInkyButton(UnityAction action)
        {
            inkyButton.onClick.AddListener(action);
        }
    }
}
