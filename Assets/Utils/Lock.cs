using System.Collections.Generic;
using System.Linq;

namespace Assets.Utils
{
    public class Lock
    {
        private readonly List<object> _retained = new List<object>();

        public void Retain(object obj)
        {
            _retained.Add(obj);
        }

        public void Release(object obj)
        {
            if (!_retained.Contains(obj))
            {
                return;
            }

            _retained.Remove(obj);
        }

        public bool IsLocked => _retained.Any();
    }
}
