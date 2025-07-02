using Assets.Model.Data;
using Assets.Utils.Disposables;
using System;
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

        public QuickInventoryData QuickInventory { get; private set; }

        public PlayerData PlayerData => _data;

        private void Awake()
        {
            LoadHud();

            if(IsSessionExitst())
            {
                DestroyImmediate(gameObject);
            }
            else
            {
                Save();
                InitModels();
                DontDestroyOnLoad(this);
            }
        }

        private void InitModels()
        {
            QuickInventory = new QuickInventoryData(PlayerData);

            _trash.Retain(QuickInventory);
        }

        private void Save()
        {
            _save = _data.Clone();
        }

        public void LoadLastSave()
        {
            _save = _data.Clone();
        }

        private void LoadHud()
        {
            SceneManager.LoadScene("Hud", LoadSceneMode.Additive);
        }

        private bool IsSessionExitst()
        {
            var sessions = FindObjectsOfType<GameSession>();

            foreach(var session in sessions)
            {
                if(session != this)
                {
                    return true;
                }
            }

            return false;
        }

        private void OnDestroy()
        {
            _trash.Dispose();
        }
    }
}
