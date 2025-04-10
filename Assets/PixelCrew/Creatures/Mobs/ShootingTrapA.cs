using Assets.CommonComponents.ColliderBased;
using Assets.CommonComponents.GameObjectBased;
using Assets.Utils;
using System;
using UnityEngine;

namespace Assets.PixelCrew.Creatures.Mobs
{
    public class ShootingTrapA : MonoBehaviour
    {
        [SerializeField]
        private LayerCollisionCheck _vision;

        [Header("Melee attack")]
        [SerializeField]
        private Cooldown _meleeCooldown;
        [SerializeField]
        private CheckCircleOverlap _meleeAttackRange;
        [SerializeField]
        private LayerCollisionCheck _meleeCanAttack;

        [Header("Range attack")]
        [SerializeField]
        private Cooldown _rangeCooldown;
        [SerializeField]
        private SpawnComponent _spawnComponent;

        private Animator _animator;

        private static readonly int MeleeTriggerHash = Animator.StringToHash("Melee Trigger");
        private static readonly int RangeTriggerHash = Animator.StringToHash("Range Trigger");

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            if (_vision.IsTouchingLayer)
            {
                if (_meleeCanAttack.IsTouchingLayer)
                {
                    if (_meleeCooldown.IsReady)
                    {
                        MeleeAtteck();
                    }

                    return;
                }

                if (_rangeCooldown.IsReady)
                {
                    RangeAttack();
                }
            }
        }

        private void RangeAttack()
        {
            _animator.SetTrigger(RangeTriggerHash);
        }

        private void MeleeAtteck()
        {
            _animator.SetTrigger(MeleeTriggerHash);
        }

        private void OnMeleeAttack()
        {
            _meleeAttackRange.Check();
        }

        private void OnRangeAttack()
        {
            _spawnComponent.Spawn("Pearl");
        }
    }
}
