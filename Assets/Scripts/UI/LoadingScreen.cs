using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.UI
{
    public class LoadingScreen : MonoBehaviour
    {
        public float Progress
        {
            get => _progress;
            set
            {
                if (value < 0) return;
                
                _progress = value;
                RefreshBar();
            }
        }

        [SerializeField] private Canvas _canvas;
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private TextMeshProUGUI _percentsLabel;
        [SerializeField] private Slider _progressBar;
        private float _progress;
        private const float FadeDuration = 0.5f;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

        public void Show()
        {
            if (_canvasGroup.alpha >= 1f) return;
            
            _canvasGroup.DOFade(1f, FadeDuration);
        }

        public void Hide()
        {
            if (_canvasGroup.alpha <= 0f) return;

            _canvasGroup.DOFade(0f, FadeDuration).OnComplete(() =>
            {
                _canvas.enabled = false;
                //   Destroy(gameObject);
            });
        }
        
        private void RefreshBar()
        {
            _progressBar.value = _progress;
            _percentsLabel.text = _progress * 100 + "%";
        }
    }
}