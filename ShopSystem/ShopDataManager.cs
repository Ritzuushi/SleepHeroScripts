using System;
using System.Collections.Generic;
using UnityEngine;
using RStudio.Utils.JsonFileSystem;

namespace RStudio.ShopSystem
{
    public class ShopDataManager : MonoBehaviour
    {
        [SerializeField]
        private ShopData _shopData;

        private void Awake()
        {
            JsonFileManager.Load.Persistent(_shopData, _shopData.name);

            _shopData.Initialize();
        }

        private void OnApplicationPause(bool pauseState)
        {
            JsonFileManager.Save.Persistent(JsonUtility.ToJson(_shopData, true), _shopData.name);
        }
    }
}
