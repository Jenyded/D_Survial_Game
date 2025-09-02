using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ToggleController : MonoBehaviour
{
    public Toggle myToggle;
   // public GameObject targetObject;
    [SerializeField] private RectTransform toggleHandle;
    [SerializeField] private Vector2 onPosition = new Vector2(20f, 0f);
    [SerializeField] private Vector2 offPosition = new Vector2(-20f, 0f);
    [SerializeField] private float moveDuration = 0.3f;

    private void Start()
    {
        if (myToggle != null)
        {
            myToggle.onValueChanged.AddListener(OnToggleChanged);
            toggleHandle.anchoredPosition = myToggle.isOn ? onPosition : offPosition;
           //targetObject.SetActive(myToggle.isOn);
        }
    }

    private void OnToggleChanged(bool isOn)
    {
        toggleHandle.DOAnchorPos(isOn ? onPosition : offPosition, moveDuration).SetEase(Ease.OutBack);
        //targetObject.SetActive(isOn);// отключение объекта
    }

    private void OnDestroy()
    {
        if (myToggle != null) myToggle.onValueChanged.RemoveListener(OnToggleChanged);
    }
}