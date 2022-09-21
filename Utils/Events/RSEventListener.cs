using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace RStudio.Utils.Events
{
    public class RSEventListener : MonoBehaviour
    {
        [SerializeField]
        private RSEvent _event;
        public RSEvent Event => _event;

        [SerializeField]
        private UnityEvent<object> _response;
        public UnityEvent<object> Response => _response;

        private void OnEnable() => _event.RegisterListener(this);

        private void OnDisable() => _event.UnregisterListener(this);

        public void OnEventRaised(object arg) => _response.Invoke(arg);
    }
}
