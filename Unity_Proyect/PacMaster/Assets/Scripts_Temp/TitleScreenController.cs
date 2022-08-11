using UnityEngine;
using com.pacmaster.utils;

namespace com.pacmaster.menu
{
    public class TitleScreenController : MonoBehaviour
    {

        [SerializeField]
        private TextFade textFade;
        [SerializeField]
        [Tooltip("The ammount that the fade should speed up once the transition begins")]
        private float fadeSpeedUp;
        [SerializeField]
        private Animator titleScreenAnimator;

        // Start is called before the first frame update
        void Start()
        {
            if (!textFade) Debug.LogWarning("There is no textFade in this Title Screen!");
            if (!titleScreenAnimator) Debug.LogWarning("There is no Animator!");
        }

        public void ActivateTitleScreen()
        {
            if (textFade) textFade.ResetSpeed();
            titleScreenAnimator.gameObject.SetActive(true);
            if (titleScreenAnimator) titleScreenAnimator.SetTrigger("FadeIn");
        }

        public void DisableTitleScreen()
        {
            if (textFade) textFade.SpeedUp(fadeSpeedUp);
            if (titleScreenAnimator) titleScreenAnimator.SetTrigger("FadeOut");
        }

    }
}
