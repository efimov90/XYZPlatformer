using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
