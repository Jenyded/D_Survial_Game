using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UIPopupPause : MonoBehaviour
{
    [SerializeField] private float fadeTime = 1f;
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private GameObject popup;
    [SerializeField] private List<GameObject> buttons = new List<GameObject>();

    public void PanelFadeIn()
    {
        popup.SetActive(true);
        canvasGroup.alpha = 0f;
        rectTransform.transform.localPosition = new Vector3(0f, -1700f, 0f);
        rectTransform.DOAnchorPos(new Vector2(0f, 0f), fadeTime, false).SetEase(Ease.OutElastic);
        canvasGroup.DOFade(1f, fadeTime);
        StartCoroutine("IButtonsAnimation");
    }

    public void PanelFadeOut()
    {
        canvasGroup.alpha = 1f;
        rectTransform.transform.localPosition = new Vector3(0f, 0f, 0f);
        rectTransform.DOAnchorPos(new Vector2(-1500f, 0f), fadeTime, false).SetEase(Ease.InOutQuint);
        canvasGroup.DOFade(0f, fadeTime);
        Invoke(nameof(DisablePopup), 0.7f);
    }

    private void DisablePopup()
    {
        popup.SetActive(false);
    }

    IEnumerator IButtonsAnimation()
    {
        foreach (var button in buttons)
        {
            button.transform.localScale = Vector3.zero;
        }

        foreach (var button in buttons)
        {
            button.transform.DOScale(1f, fadeTime).SetEase(Ease.OutBounce);
            yield return new WaitForSeconds(0.25f);
        }
    }
}