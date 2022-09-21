using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RStudio.Utils.Events
{
    [CreateAssetMenu]
    public class RSEvent : ScriptableObject
    {
        private List<RSEventListener> _listeners = new List<RSEventListener>();

        public void Raise(object arg)
        {
            for (int i = _listeners.Count - 1; i >= 0; i--)
            {
                _listeners[i].OnEventRaised(arg);
            }
        }

        public void RegisterListener(RSEventListener listener) => _listeners.Add(listener);

        public void UnregisterListener(RSEventListener listener) => _listeners.Remove(listener);
    }
}
