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
                DontDestroyOnLoad(this);
            }
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
