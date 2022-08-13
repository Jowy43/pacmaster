using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using com.pacmaster.events;

namespace com.pacmaster.character
{
    public class PacmanCollissionController : MonoBehaviour
    {

        [SerializeField]
        private GameEvent smallPellet;

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("Hola");
            if (other.name.StartsWith("Little"))
            {
                smallPellet.ActivateEvent();
                Destroy(other.gameObject);
            }
        }

    }
}
