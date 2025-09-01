using Assets.Model.Definitions.Repositories;
using System.Collections.Generic;

namespace Assets.Model.Extensions
{
    public static class ItemWithCountExtensions
    {
        public static IDictionary<string, int> ToDictionary(this IEnumerable<ItemWithCount> itemWithCounts)
        {
            var joined = new Dictionary<string, int>();

            foreach (var requiredItem in itemWithCounts)
            {
                if (joined.ContainsKey(requiredItem.Id))
                {
                    joined[requiredItem.Id] += requiredItem.Count;
                }
                else
                {
                    joined.Add(requiredItem.Id, requiredItem.Count);
                }
            }

            return joined;
        }
    }
}
