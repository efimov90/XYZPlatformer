using Assets.CommonComponents;
using Assets.PixelCrew.Creatures.Behaviours;
using System;
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

        private Patrol _patrol;

        [SerializeField]
        private float _attackCooldown = 1f;

        private SpawnComponent _spawnComponent;

        private Coroutine _currentCoroutine;
        private GameObject _target;

        private bool _isAgro = false;

        private void Awake()
        {
            _spawnComponent = GetComponent<SpawnComponent>();
            _creature = GetComponent<Creature>();
            _patrol = GetComponent<Patrol>();
        }

        private void Start()
        {
            StartState(_patrol.DoPatrol());
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
                if (_attackCheck.IsTouchingLayer)
                {
                    StartState(Attack());
                }
                else
                {
                    SetDirectionToTarget();
                }
                yield return null;
            }

            _spawnComponent.Spawn("Interrogation");
            _isAgro = false;
            ResetDirection();
            StartState(_patrol.DoPatrol());
        }

        private IEnumerator Attack()
        {
            ResetDirection();

            while (_attackCheck.IsTouchingLayer)
            {
                _creature.Attack();
                yield return new WaitForSeconds(_attackCooldown);
            }

            if (_visionCheck.IsTouchingLayer)
            {
                StartState(Chasing());
            }
            else
            {
                _isAgro = false;
                _spawnComponent.Spawn("Interrogation");
                StartState(_patrol.DoPatrol());
            }
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

        public void Die()
        {
            if (_currentCoroutine != null)
            {
                StopCoroutine(_currentCoroutine);
            }

            ResetDirection();

            _creature.Die();
        }

        private void StartState(IEnumerator coroutine)
        {
            if (_creature.IsDead)
            {
                if (_currentCoroutine != null)
                {
                    StopCoroutine(_currentCoroutine);
                }

                return;
            }

            if (_currentCoroutine != null)
            {
                StopCoroutine(_currentCoroutine);
            }

            _currentCoroutine = StartCoroutine(coroutine);
        }
    }
}
