using Assets.PixelCrew.Creatures.Hero;
using Cinemachine;
using UnityEngine;

namespace Assets.PixelCrew.CommonComponents.SceneManagement
{
    public class SetFollowComponent : MonoBehaviour
    {
        private void Start()
        {
            GameObject.FindWithTag("FollowCamera")
                .GetComponent<CinemachineVirtualCamera>()
                .Follow = FindObjectOfType<Hero>().transform;
        }
    }
}
