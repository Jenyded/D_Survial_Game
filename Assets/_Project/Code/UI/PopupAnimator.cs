using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PopupAnimator : MonoBehaviour
{
    [SerializeField] private CanvasGroup popupCanvasGroup;
    [SerializeField] private GameObject anticlicker;
    [SerializeField] private Button[] showButtons;
    [SerializeField] private Button closeButton;
    [SerializeField] private float fadeDuration = 0.5f;

    private void Start()
    {
        popupCanvasGroup.alpha = 0f;
        popupCanvasGroup.interactable = false;
        popupCanvasGroup.blocksRaycasts = false;
        anticlicker.SetActive(false);
        
        foreach (Button button in showButtons)
        {
            button.onClick.AddListener(ShowPopup);
        }
        closeButton.onClick.AddListener(HidePopup);
    }

    private void ShowPopup()
    {
        anticlicker.SetActive(true);
        popupCanvasGroup.DOFade(1f, fadeDuration)
            .OnStart(() =>
            {
                popupCanvasGroup.interactable = true;
                popupCanvasGroup.blocksRaycasts = true;
            })
            .SetEase(Ease.OutQuad);
    }

    private void HidePopup()
    {
        popupCanvasGroup.DOFade(0f, fadeDuration)
            .OnComplete(() =>
            {
                popupCanvasGroup.interactable = false;
                popupCanvasGroup.blocksRaycasts = false;
                anticlicker.SetActive(false);
            })
            .SetEase(Ease.InQuad);
    }

    private void OnDestroy()
    {
        foreach (Button button in showButtons)
        {
            button.onClick.RemoveListener(ShowPopup);
        }
        closeButton.onClick.RemoveListener(HidePopup);
    }
}