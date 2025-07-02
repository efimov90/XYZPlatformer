using Assets.CommonComponents.ColliderBased;
using Assets.CommonComponents.Cooldowns;
using Assets.CommonComponents.Spawners;
using UnityEngine;

namespace Assets.PixelCrew.Creatures.Mobs
{
    public class TotemHead : MonoBehaviour
    {
        [SerializeField]
        private LayerCollisionCheck _vision;

        [Header("Range attack")]
        [SerializeField]
        public CooldownComponent _rangeCooldownComponent;

        [SerializeField]
        private SpawnComponent _spawnComponent;

        private Animator _animator;
        private static readonly int RangeTriggerHash = Animator.StringToHash("Attack Trigger");

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            if (_vision.IsTouchingLayer)
            {
                if (_rangeCooldownComponent.IsReady)
                {
                    _rangeCooldownComponent.Reset();
                    RangeAttack();
                }
            }
        }

        private void RangeAttack()
        {
            _animator.SetTrigger(RangeTriggerHash);
        }

        private void OnRangeAttack()
        {
            _spawnComponent.Spawn("Pearl");
        }
    }
}