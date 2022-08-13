using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace com.pacmaster.events
{
    [CreateAssetMenu(fileName = "GameEvent", menuName = "Events/Game Event")]
    public class GameEvent : ScriptableObject
    {

        public List<UnityAction> actions = new List<UnityAction>();

        public void RegisterListener(UnityAction action)
        {
            actions.Add(action);
        }

        public void UnregisterListener(UnityAction action)
        {
            actions.Remove(action);
        }

        public void ActivateEvent()
        {
            actions.ForEach(a => a.Invoke());
        }

    }
}

