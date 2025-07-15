using Assets.Model.Definitions.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Model.Data
{
    [Serializable]
    public class LevelData
    {
        [SerializeField]
        private List<LevelProgress> _progresses;

        public int GetLevel(StatId statId)
            => _progresses.FirstOrDefault(x => x.Id == statId)?.Level ?? 0;

        public void LevelUp(StatId statId)
        {
            if (!(_progresses.FirstOrDefault(x => x.Id == statId) is LevelProgress levelProgress))
            {
                levelProgress = new LevelProgress(statId);
                _progresses.Add(levelProgress);
            }

            levelProgress.Level++;
        }
    }
}
