using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace com.pacmaster.utils
{
    public class LevelTransition : MonoBehaviour
    {
        [SerializeField]
        private Animator animator;
        [SerializeField]
        private Image image;

        private int level;

        public void StartLevelTransition(Color color, int level)
        {
            this.level = level;
            SetImageColor(color);
            animator.SetTrigger("EndLevel");
        }

        public void TransitionLevel()
        {
            SceneManager.LoadScene(level);
        }

        public void SetImageColor(Color color)
        {
            image.color = color;
        }
    }
}