using System;
using System.Collections.Generic;
using UnityEngine;

namespace RStudio.ShopSystem
{
    [CreateAssetMenu]
    public class ShopData : ScriptableObject
    {
        public int BedLevel;
        public int TableLevel;
        public int LampLevel;
        public int RugLevel;
        public int WindowLevel;
        public int CurtainLevel;

        public int BedMaxLevel;
        public int TableMaxLevel;
        public int LampMaxLevel;
        public int RugMaxLevel;
        public int WindowMaxLevel;
        public int CurtainMaxLevel;

        [SerializeField]
        private bool _isInitial;

        public void Initialize()
        {
            if (!_isInitial)
            {
                BedLevel = 0;
                TableLevel = 0;
                LampLevel = 0;
                RugLevel = 0;
                WindowLevel = 0;
                CurtainLevel = 0;

                BedMaxLevel = 0;
                TableMaxLevel = 0;
                LampMaxLevel = 0;
                RugMaxLevel = 0;
                WindowMaxLevel = 0;
                CurtainMaxLevel = 0;
            }
            _isInitial = true;
        }
    }
}
