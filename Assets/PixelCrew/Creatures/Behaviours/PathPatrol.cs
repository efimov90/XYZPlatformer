using System.Collections;
using UnityEngine;

namespace Assets.PixelCrew.Creatures.Behaviours
{
    public class PathPatrol : Patrol
    {
        [SerializeField]
        private Transform[] _path;

        [SerializeField]
        private float _treshhold = 1f;

        private int _destinationTargetIndex = 0;

        private Creature _creature;

        private void Awake()
        {
            _creature = GetComponent<Creature>();
        }

        public override IEnumerator DoPatrol()
        {
            while (enabled)
            {
                if (IsOnPoint())
                {
                    _destinationTargetIndex = (int)Mathf.Repeat(_destinationTargetIndex + 1, _path.Length);

                }

                var currentDirection = _path[_destinationTargetIndex].position - transform.position;
                currentDirection.y = 0f;

                _creature.SetDirection(currentDirection.normalized);

                yield return null;
            }
        }

        private bool IsOnPoint() => (_path[_destinationTargetIndex].position - transform.position).magnitude < _treshhold;
    }
}
