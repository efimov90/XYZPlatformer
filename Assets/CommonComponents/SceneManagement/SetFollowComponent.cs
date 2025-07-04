using Assets.PixelCrew.Creatures.Hero;
using Cinemachine;
using UnityEngine;

namespace Assets.CommonComponents.SceneManagement
{
    public class SetFollowComponent : MonoBehaviour
    {
        private void Start()
        {
            FindObjectOfType<CinemachineVirtualCamera>()
                .Follow = FindObjectOfType<Hero>().transform;
        }
    }
}
