using Assets.Utils;
using UnityEngine;

namespace Assets.PixelCrew.CommonComponents.Dialogs
{
    public class ShowWindowComponent : MonoBehaviour
    {
        [SerializeField]
        private string _path;

        public void Show()
        {
            WindowUtils.CreateWindow(_path);
        }
    }
}
