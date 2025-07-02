using UnityEngine;

namespace Assets.CommonComponents.Spawners
{
    public class SpawnRandomComponent : MonoBehaviour
    {
        [SerializeField]
        SpawnComponent _spawnComponent;

        public void SpawnRandomCoins()
        {
            var silverCoinsCount = (int)Random.Range(0f, 5f);

            for (int i = 0; i < silverCoinsCount; i++)
            {
                _spawnComponent.Spawn("GoldCoin");
            }

            var goldCoinsCount = (int)Random.Range(0f, 5f);

            for (int i = 0; i < goldCoinsCount; i++)
            {
                _spawnComponent.Spawn("SilverCoin");
            }
        }
    }
}
