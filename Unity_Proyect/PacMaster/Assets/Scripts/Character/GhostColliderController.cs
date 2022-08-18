using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using com.pacmaster.events;

namespace com.pacmaster.character
{
    public class GhostColliderController : MonoBehaviour
    {
        [SerializeField]
        private GameEvent ghostWins;

        [SerializeField]
        private GameObject pacman;

        private void OnControllerColliderHit(ControllerColliderHit hit)
        {
            if (hit.gameObject.Equals(pacman))
            {
                ghostWins.ActivateEvent();
            }
        }
    }
}
