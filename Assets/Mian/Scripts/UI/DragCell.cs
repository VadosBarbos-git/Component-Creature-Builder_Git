using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DragCell : MonoBehaviour
{
    [SerializeField] private RectTransform _RectTransform;
    [SerializeField] private Image _image;
    [SerializeField] private TextMeshProUGUI _text;

    /* [SerializeField] private RectTransform m_RectTransform;
     [SerializeField] private Image _image;
     [SerializeField] private TextMeshProUGUI _text;*/
    public void EnableDragCell(string text, Vector2 anchoredPosition)
    {

        _text.raycastTarget = false;
        _text.text = text;
        _RectTransform.anchoredPosition = anchoredPosition;
        _image.enabled = true;
        _text.enabled = true;

    }
    public void MoveDragCell(Vector3 anchoredPosition)
    {
        _RectTransform.anchoredPosition = anchoredPosition;
    }
    public void DisableDragCell()
    {
        _image.enabled = false;
        _text.enabled = false;
    }

    public Transform GetParentRect()
    {
        return _RectTransform.parent;

    }
}
