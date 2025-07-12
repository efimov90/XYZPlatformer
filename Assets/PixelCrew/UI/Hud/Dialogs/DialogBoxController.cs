using Assets.Model.Data.Dialogs;
using Assets.Utils;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.CommonComponents.UI.Hud.Dialogs
{
    public class DialogBoxController : MonoBehaviour
    {
        private static readonly int IsOpen = Animator.StringToHash("IsOpen");

        [SerializeField]
        private Text _text;

        [SerializeField]
        private GameObject _container;

        [SerializeField]
        private Animator _animator;

        [Space]
        [SerializeField]
        private float _textSpeed = 0.09f;

        [Header("Sounds")]
        [SerializeField]
        private AudioClip _typing;

        [SerializeField]
        private AudioClip _open;

        [SerializeField]
        private AudioClip _close;

        private DialogData _dialogData;

        private int _currentSentenceIndex;

        private AudioSource _sfxSource;

        private Coroutine _typingCoroutine;

        public void ShowDialog(DialogData dialogData)
        {
            _dialogData = dialogData;
            _currentSentenceIndex = 0;
            _text.text = "";

            _container.SetActive(true);

            _sfxSource = AudioUtils.FindSfxSource();
            _sfxSource.PlayOneShot(_open);
            _animator.SetBool(IsOpen, true);
        }

        public void OnSkip()
        {
            if (_typingCoroutine == null)
            {
                return;
            }

            StopTypeAnimation();
        }

        public void OnContinue()
        {
            StopTypeAnimation();

            _currentSentenceIndex++;

            if (_currentSentenceIndex >= _dialogData.Sentences.Length)
            {
                HideDialogBox();
                return;
            }

            OnStartDialogAnimation();
        }

        private void OnStartDialogAnimation()
        {
            _typingCoroutine = StartCoroutine(TypeDialogText());
        }

        private IEnumerator TypeDialogText()
        {
            _text.text = "";
            var sentence = _dialogData.Sentences[_currentSentenceIndex];

            foreach (var letter in sentence)
            {
                _text.text += letter;
                _sfxSource.PlayOneShot(_typing);
                yield return new WaitForSeconds(_textSpeed);
            }

            _typingCoroutine = null;
        }

        private void StopTypeAnimation()
        {
            if (_typingCoroutine == null)
            {
                return;
            }

            StopCoroutine(_typingCoroutine);
            _typingCoroutine = null;

            _text.text = _dialogData.Sentences[_currentSentenceIndex];
        }

        private void OnCloseAnimationComplete()
        {

        }

        private void HideDialogBox()
        {
            _animator.SetBool(IsOpen, false);

            if (_close != null)
            {
                _sfxSource.PlayOneShot(_close);
            }
        }
    }
}
