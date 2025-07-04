using Assets.CommonComponents.Spawners;
using Assets.Model;
using System;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.CommonComponents.SceneManagement
{
    public class CheckPointComponent : MonoBehaviour
    {
        [SerializeField]
        private string _id;

        [SerializeField]
        private UnityEvent _setChecked;

        [SerializeField]
        private UnityEvent _setUnchecked;

        [SerializeField]
        private AdjustableSpawnComponent _heroSpawnComponent;

        private GameSession _gameSession;

        public string Id => _id;

        public void Start()
        {
            _gameSession = FindObjectOfType<GameSession>();

            if (_gameSession.IsChecked(_id))
            {
                _setChecked?.Invoke();
            }
            else
            {
                _setUnchecked?.Invoke();
            }
        }

        public void Check()
        {
            Debug.Log($"Checkpoint with id {_id} is checked.");
            _gameSession.SetChecked(_id);
            _setChecked?.Invoke();
        }

        public void Uncheck()
        {
            _setUnchecked?.Invoke();
        }

        public void SpawnHero()
        {
            if (_heroSpawnComponent == null)
            {
                Debug.LogWarning("Hero spawn component is not assigned.");
                return;
            }

            _heroSpawnComponent.Spawn();
        }
    }
}
