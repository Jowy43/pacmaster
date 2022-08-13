using UnityEngine;
using TMPro;

namespace com.pacmaster.utils
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class TextFade : MonoBehaviour
    {

        [SerializeField]
        [Tooltip("The Color it should fade Towards")]
        private Color fadeColorTowards;

        [SerializeField]
        [Tooltip("Speed of the fade efect")]
        [Range(1f, 10f)]
        private float fadeSpeed;
        private float initialFadeSpeed;

        [SerializeField]
        [Tooltip("Min and Max Fade ammount (cap on 0 and 1)")]
        private Vector2 fadeRange;

        [SerializeField]
        [Tooltip("True if it should bounce back and forth")]
        private bool bounce;

        /*Private fields*/
        private Color _initialColor;
        private Color _endColor;
        private TextMeshProUGUI _textMesh;
        private float _fadeStart = 0;
        private readonly float fadeTime = 1;


        // Start is called before the first frame update
        void Start()
        {
            initialFadeSpeed = fadeSpeed;
            fadeRange = FixVector2(fadeRange);
            _textMesh = GetComponent<TextMeshProUGUI>();
            _initialColor = Color.Lerp(_textMesh.color, fadeColorTowards, fadeRange.x);
            _endColor = Color.Lerp(_textMesh.color, fadeColorTowards, fadeRange.y);
        }

        // Update is called once per frame
        void Update()
        {
            ColorFade();
        }

        private void ColorFade()
        {
            if (_fadeStart <= fadeTime)
            {
                _fadeStart += Time.deltaTime * fadeSpeed;
                _textMesh.color = Color.Lerp(_initialColor, _endColor, _fadeStart);
                if (fadeTime < _fadeStart)
                {
                    _textMesh.color = _endColor;
                }
            } else if (bounce)
            {
                _fadeStart = 0;
                _endColor = _initialColor;
                _initialColor = _textMesh.color;
            }
        }

        /// <summary>
        /// Clamps and reorders vector 2 so that min is x and max is y
        /// </summary>
        /// <param name="vector">Vector to fix</param>
        /// <returns>fixed Vector2</returns>
        private Vector2 FixVector2(Vector2 vector)
        {
            if (vector.x > 1)
            {
                vector.x = 1;
            }
            else if (vector.x < 0)
            {
                vector.x = 0;
            }
            if (vector.y > 1)
            {
                vector.y = 1;
            }
            else if (vector.y < 0)
            {
                vector.y = 0;
            }
            if (vector.x > vector.y)
            {
                float aux = vector.x;
                vector.x = vector.y;
                vector.y = aux;
            }
            return vector;
        }

        /// <summary>
        /// Speeds the fade up a notch
        /// </summary>
        /// <param name="speed">the ammount to speed up</param>
        public void SpeedUp(float speed)
        {
            fadeSpeed += speed;
        }

        public void ResetSpeed()
        {
            fadeSpeed = initialFadeSpeed;
        }
    }
}
