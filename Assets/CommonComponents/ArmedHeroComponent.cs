using Assets.PixelCrew.Creatures;
using UnityEngine;

namespace Assets.CommonComponents
{
    public class ArmedHeroComponent : MonoBehaviour
    {
        public void ArmHero(GameObject gameObject)
        {
            if(gameObject.GetComponent<Hero>() is Hero hero)
            {
                hero.ArmHero();
            }
        }
    }
}
