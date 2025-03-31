using System;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Utils
{
    [Serializable]
    public class Cheat
    {
        [SerializeField]
        public string CheatCode;
        [SerializeField]
        public UnityEvent Action;
    }
}