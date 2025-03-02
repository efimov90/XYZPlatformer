using System;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.CommonComponents
{
    [Serializable]
    public class OnOverlapEvent : UnityEvent<GameObject>
    {
    }
}
