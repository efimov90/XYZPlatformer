using System;
using UnityEngine;

namespace Assets.PixelCrew.Model
{
    [Serializable]
    public class GameSession : MonoBehaviour
    {
        [SerializeField]
        private PlayerData _data;

        public PlayerData PlayerData => _data;

        private void Awake()
        {
            if(IsSessionExitst())
            {
                DestroyImmediate(gameObject);
            }
            else
            {
                DontDestroyOnLoad(this);
            }
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
