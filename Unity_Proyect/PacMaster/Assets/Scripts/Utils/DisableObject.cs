using UnityEngine;

namespace com.pacmaster.utils
{
    public class DisableObject : MonoBehaviour
    {
        public void DisableCurrentObject()
        {
            gameObject.SetActive(false);
        }
    }
}
