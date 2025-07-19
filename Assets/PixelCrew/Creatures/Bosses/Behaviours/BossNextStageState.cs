using Assets.PixelCrew.CommonComponents;
using Assets.PixelCrew.CommonComponents.Spawners;
using UnityEngine;

namespace Assets.PixelCrew.Creatures.Bosses.Behaviours
{
    public class BossNextStageState : StateMachineBehaviour
    {
        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            var spawner = animator.GetComponent<CircularProjectileSpawner>();
            spawner.Stage++;
            var changeLights = animator.GetComponent<ChangeLightsComponent>();
            changeLights.SetColor();
        }
    }
}