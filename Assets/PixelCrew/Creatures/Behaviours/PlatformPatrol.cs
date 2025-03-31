using Assets.CommonComponents.ColliderBased;
using System.Collections;
using UnityEngine;

namespace Assets.PixelCrew.Creatures.Behaviours
{
    public class PlatformPatrol : Patrol
    {
        [SerializeField]
        private LayerCollisionCheck _groundProbe;

        private Creature _creature;

        private void Awake()
        {
            _creature = GetComponent<Creature>();
        }

        public override IEnumerator DoPatrol()
        {
            while (enabled)
            {
                if(_creature.Direction == Vector2.zero)
                {
                    var direction = _creature.transform.lossyScale.normalized;
                    direction.y = 0;
                    _creature.SetDirection(direction);
                }

                if (!_groundProbe.IsTouchingLayer)
                {
                    var newDirection = _creature.transform.position - _groundProbe.transform.position;
                    newDirection.y = 0;

                    _creature.SetDirection(newDirection.normalized);

                    yield return new WaitForSeconds(1);
                }

                yield return null;
            }
        }
    }
}
