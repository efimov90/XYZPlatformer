using System;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.PixelCrew.CommonComponents.ColliderBased
{
    [Serializable]
    public class OnOverlapEvent : UnityEvent<GameObject>
    {
    }
}
