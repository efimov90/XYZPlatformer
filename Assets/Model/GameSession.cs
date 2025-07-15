using Assets.PixelCrew.CommonComponents.SceneManagement;
using Assets.Model.Data;
using Assets.Utils.Disposables;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Model
{
    [Serializable]
    public class GameSession : MonoBehaviour
    {
        private readonly CompositeDisposable _trash = new CompositeDisposable();

        [SerializeField]
        private PlayerData _data;

        private PlayerData _save;

        [SerializeField]
        private string _defaultCheckpointId;

        private List<string> _chechedCheckpoints = new List<string>();

        public QuickInventoryData QuickInventory { get; private set; }

        public PerksModel PerksModel { get; private set; }

        public StatsModel StatsModel { get; private set; }

        public PlayerData PlayerData => _data;

        public bool IsChecked(string id)
            => _chechedCheckpoints.Contains(id);

        public void SetChecked(string id)
        {
            if (IsChecked(id))
            {
                return;
            }

            Save();
            _chechedCheckpoints.Add(id);
        }

        private void Awake()
        {
            if (GetExistingSession() is GameSession gameSession)
            {
                gameSession.StartSesion(_defaultCheckpointId);
                Destroy(gameObject);
            }
            else
            {
                InitModels();
                DontDestroyOnLoad(this);
                StartSesion(_defaultCheckpointId);
            }
        }

        private void StartSesion(string defaultCheckpointId)
        {
            SetChecked(defaultCheckpointId);

            LoadHud();
            SpawnHero(defaultCheckpointId);
        }

        private void SpawnHero(string defaultCheckpointId)
        {
            var lastCheckpointId = _chechedCheckpoints.Last();

            FindObjectsOfType<CheckPointComponent>()
                .FirstOrDefault(cp => cp.Id == lastCheckpointId)
                ?.SpawnHero();
        }

        private void InitModels()
        {
            QuickInventory = new QuickInventoryData(PlayerData);

            _trash.Retain(QuickInventory);

            PerksModel = new PerksModel(_data);
            _trash.Retain(PerksModel);

            StatsModel = new StatsModel(_data);
            _trash.Retain(StatsModel);
        }

        private void Save()
        {
            _save = _data.Clone();
        }

        public void LoadLastSave()
        {
            _data = _save.Clone();

            _trash.Dispose();
            InitModels();
        }

        private void LoadHud()
        {
            SceneManager.LoadScene("Hud", LoadSceneMode.Additive);
        }

        private GameSession GetExistingSession()
        {
            var sessions = FindObjectsOfType<GameSession>();

            foreach (var session in sessions)
            {
                if (session != this)
                {
                    return session;
                }
            }

            return null;
        }

        private void OnDestroy()
        {
            _trash.Dispose();
        }
    }
}
