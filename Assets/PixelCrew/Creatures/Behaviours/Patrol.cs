using System.Collections;
using UnityEngine;

namespace Assets.PixelCrew.Creatures.Behaviours
{
    public abstract class Patrol : MonoBehaviour
    {
        public abstract IEnumerator DoPatrol();
    }
}
