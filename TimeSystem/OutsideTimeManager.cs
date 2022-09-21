using System;
using System.Collections.Generic;
using UnityEngine;

namespace RStudio.TimeSystem
{
    public class OutsideTimeManager : MonoBehaviour
    {
        [SerializeField]
        private Transform _outsideTransform;

        public void SetOutsideTransform(int value)
        {
            switch (value)
            {
                case 0:
                    _outsideTransform.localPosition = new Vector3(0, -0.02f, 0);
                    _outsideTransform.localScale = new Vector3(1, 1, 1);
                    break;
                case 1:
                    _outsideTransform.localPosition = new Vector3(0, 0, 0);
                    _outsideTransform.localScale = new Vector3(1.11f, 1.18f, 0);
                    break;
                case 2:
                    _outsideTransform.localPosition = new Vector3(0.02f, 0, 0);
                    _outsideTransform.localScale = new Vector3(1.08f, 1.48f, 0);
                    break;
                default:
                    return;
            }
        }
    }
}
