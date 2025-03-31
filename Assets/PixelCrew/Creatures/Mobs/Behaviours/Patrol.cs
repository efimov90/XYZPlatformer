using System.Collections;
using UnityEngine;

namespace Assets.PixelCrew.Creatures.Mobs.Behaviours
{
    public abstract class Patrol : MonoBehaviour
    {
        public abstract IEnumerator DoPatrol();
    }
}
