using Assets.Model.Data;
using Assets.Model.Definitions.Player;
using Assets.PixelCrew.CommonComponents.SceneManagement;
using Assets.Utils.Disposables;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

namespace Assets.Model
{
    [Serializable]
    public class GameSession : MonoBehaviour
    {
        private readonly CompositeDisposable _trash = new CompositeDisposable();

        [SerializeField]
        private int _userLevel;

        [SerializeField]
        private PlayerData _data;

        private PlayerData _save;

        [SerializeField]
        private string _defaultCheckpointId;

        private List<string> _chechedCheckpoints = new List<string>();

        public QuickInventoryData QuickInventory { get; private set; }

        public InventoryModel Inventory { get; private set; }

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
                gameSession.StartSesion(_defaultCheckpointId, _userLevel);
                Destroy(gameObject);
            }
            else
            {
                InitModels();
                DontDestroyOnLoad(this);
                StartSesion(_defaultCheckpointId, _userLevel);
            }
        }

        private void StartSesion(string defaultCheckpointId, int userLevel)
        {

            SetChecked(defaultCheckpointId);

            TrackSessionStart(userLevel);

            LoadUIs();
            SpawnHero(defaultCheckpointId);
        }

        private void TrackSessionStart(int userLevel)
        {
            AnalyticsEvent.Custom("level_start", new Dictionary<string, object>
            {
                { "userLevel", userLevel }
            });
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

            Inventory = new InventoryModel(_data);

            _data.Health.Value = (int)StatsModel.GetCurrentValue(StatId.Health);
        }

        public void Save()
        {
            _save = _data.Clone();
        }

        public void LoadLastSave()
        {
            _data = _save.Clone();

            _trash.Dispose();
            InitModels();
        }

        private void LoadUIs()
        {
            SceneManager.LoadScene("Hud", LoadSceneMode.Additive);
            LoadOnScreenControls();
        }

        [Conditional("USE_ON_SCREEN_CONTROLS")]
        private void LoadOnScreenControls()
        {
            SceneManager.LoadScene("Controls", LoadSceneMode.Additive);
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
