using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using com.pacmaster.events;

namespace com.pacmaster.utils
{
    public class Countdown : MonoBehaviour
    {
        [SerializeField]
        private GameEvent gameEvent;


        public void CountdownEnd()
        {
            gameEvent.ActivateEvent();
        }

    }
}
