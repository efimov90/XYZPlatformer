using System;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.CommonComponents.ColliderBased
{
    [Serializable]
    public class EnterEvent : UnityEvent<GameObject>
    {
    }
}
