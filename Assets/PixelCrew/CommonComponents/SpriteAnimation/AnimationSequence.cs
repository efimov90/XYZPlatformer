using System;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.PixelCrew.CommonComponents.SpriteAnimation
{
    [Serializable]
    public class AnimationSequence
    {
        [SerializeField]
        public string Name;

        [SerializeField]
        public int FrameRate;

        [SerializeField]
        public bool Loop;

        [SerializeField]
        public Sprite[] Sprites;

        [SerializeField]
        public UnityEvent OnAnimationEnd;
    }
}
