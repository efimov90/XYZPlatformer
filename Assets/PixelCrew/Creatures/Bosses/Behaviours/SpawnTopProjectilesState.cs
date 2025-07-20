using UnityEngine;

namespace Assets.PixelCrew.Creatures.Bosses.Behaviours
{
    public class SpawnTopProjectilesState : StateMachineBehaviour
    {
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            var boss = animator.GetComponent<DavidTheCrabby>();
            boss.SpawnTopProjectiles();
        }
    }
}
