using System;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.CommonComponents.ColliderBased
{
    [Serializable]
    public class OnOverlapEvent : UnityEvent<GameObject>
    {
    }
}
