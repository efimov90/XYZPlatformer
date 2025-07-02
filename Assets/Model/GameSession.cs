using Assets.Model.Data;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Model
{
    [Serializable]
    public class GameSession : MonoBehaviour
    {
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
        }

        private void Save()
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
    }
}
