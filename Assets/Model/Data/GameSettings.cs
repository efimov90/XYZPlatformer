using Assets.Model.Data.Properties;
using UnityEngine;

namespace Assets.Model.Data
{
    [CreateAssetMenu(menuName = "Data/GameSettings", fileName = "GameSettings")]
    public partial class GameSettings : ScriptableObject
    {
        [SerializeField]
        private FloatPersistentProperty _music;

        [SerializeField]
        private FloatPersistentProperty _sfx;

        private static GameSettings _instance;

        public static GameSettings Instance
            => _instance == null ? LoadGameSettings() : _instance;

        public FloatPersistentProperty Music => _music;

        public FloatPersistentProperty Sfx => _sfx;

        private static GameSettings LoadGameSettings()
            => Resources.Load<GameSettings>("GameSettings");

        private void OnEnable()
        {
            _music = new FloatPersistentProperty(1, SoundSetting.Music.ToString());
            _sfx = new FloatPersistentProperty(1, SoundSetting.Sfx.ToString());
        }

        private void OnValidate()
        {
            _music.Validate();
            _sfx.Validate();
        }
    }
}
