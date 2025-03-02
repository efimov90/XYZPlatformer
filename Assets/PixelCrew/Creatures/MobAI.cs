using Assets.CommonComponents;
using System.Collections;
using UnityEngine;

namespace Assets.PixelCrew.Creatures
{
    public class MobAI : MonoBehaviour
    {
        [SerializeField]
        private LayerCollisionCheck _visionCheck;
        
        [SerializeField]
        private LayerCollisionCheck _attackCheck;

        private Creature _creature;

        [SerializeField]
        private float _alarmDelay = 1f;

        private SpawnComponent _spawnComponent;

        private Coroutine _currentCoroutine;
        private GameObject _target;

        private bool _isAgro = false;

        private void Awake()
        {
            _spawnComponent = GetComponent<SpawnComponent>();
            _creature = GetComponent<Creature>();
        }

        private void Start()
        {
            StartState(Patrolling());
        }

        public void OnHeroInVision(GameObject hero)
        {
            _target = hero;

            StartState(AgroToHero());
        }

        private IEnumerator AgroToHero()
        {
            if (!_isAgro)
            {
                _spawnComponent.Spawn("Exclamation");
                _isAgro = true;
            }

            yield return new WaitForSeconds(_alarmDelay);

            StartState(Chasing());
        }

        private IEnumerator Chasing()
        {
            while (_visionCheck.IsTouchingLayer)
            {
                SetDirectionToTarget();
                yield return null;
            }

            _spawnComponent.Spawn("Interrogation");
            _isAgro = false;
            ResetDirection();
            StartState(Patrolling());
        }

        private void SetDirectionToTarget()
        {
            var directionToTarget = _target.transform.position - transform.position;
            directionToTarget.y = 0;
            _creature.SetDirection(directionToTarget.normalized);
        }

        private void ResetDirection()
        {
            _creature.SetDirection(Vector3.zero);
        }

        private IEnumerator Patrolling()
        {
            yield return null;
        }

        private void StartState(IEnumerator coroutine)
        {
            if(_currentCoroutine != null)
            {
                StopCoroutine(_currentCoroutine);
            }

            _currentCoroutine = StartCoroutine(coroutine);
        }
    }
}
