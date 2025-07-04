using System;
using UnityEngine.Events;

namespace Assets.CommonComponents.UI.Windows.Localization
{
    [Serializable]
    public class SelectLocale : UnityEvent<string>
    {
    }
}
