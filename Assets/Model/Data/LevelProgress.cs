using Assets.Model.Definitions.Player;
using System;

namespace Assets.Model.Data
{
    [Serializable]
    public class LevelProgress
    {
        public StatId Id;
        public int Level;

        public LevelProgress(StatId statId)
        {
            Id = statId;
            Level = 0;
        }
    }
}
