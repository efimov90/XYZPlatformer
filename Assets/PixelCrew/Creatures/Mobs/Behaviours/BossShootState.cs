using Assets.PixelCrew.CommonComponents.Spawners;
using UnityEngine;

namespace Assets.PixelCrew.Creatures.Mobs.Behaviours
{
    public class BossShootState : StateMachineBehaviour
    {
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            animator
                .GetComponent<CircularProjectileSpawner>()
                ?.LaunchProjectiles();
        }
    }
}