using Assets.CommonComponents.ColliderBased;
using Assets.CommonComponents.GameObjectBased;
using Assets.Utils;
using UnityEngine;

namespace Assets.PixelCrew.Creatures.Mobs
{
    public class TotemHead : MonoBehaviour
    {
        [SerializeField]
        private LayerCollisionCheck _vision;

        [Header("Range attack")]
        [SerializeField]
        private Cooldown _rangeCooldown;
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

        private void OnRangeAttack()
        {
            _rangeCooldown.Reset();
            _spawnComponent.Spawn("Pearl");
        }
    }
}