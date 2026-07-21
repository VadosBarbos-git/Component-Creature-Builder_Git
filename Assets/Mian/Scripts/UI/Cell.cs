
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Cell : MonoBehaviour, IDragHandler, IBeginDragHandler
{
    public static Cell CurentCell;
    private ComponentDefinition _curentComponent;

    private Image _image;
    private TextMeshProUGUI _textNameCell;

    private RectTransform _rectTransform;

    private DragCell DragCell;
    public void OnBeginDrag(PointerEventData eventData)
    {
        CurentCell = this;
        if (_image == null) _image = GetComponent<Image>();
        if (_textNameCell == null) _textNameCell = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        if (_rectTransform == null) _rectTransform = GetComponent<RectTransform>();

        _image.raycastTarget = false;
        _textNameCell.raycastTarget = false;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(
         _rectTransform.parent as RectTransform,
         eventData.position,
         eventData.pressEventCamera,
         out Vector2 localPos
     );


        _image.enabled = false;
        _textNameCell.enabled = false;
        DragCell.EnableDragCell(_textNameCell.text, _rectTransform.anchoredPosition);
    }

    public void OnDrag(PointerEventData eventData)
    {

        RectTransformUtility.ScreenPointToLocalPointInRectangle(

       DragCell.GetParentRect() as RectTransform,
       eventData.position,
       eventData.pressEventCamera,
       out Vector2 localPos
   );

        DragCell.MoveDragCell((Vector3)localPos);
    }



    public void SetCell(ComponentDefinition component, DragCell dragCell)
    {
        _curentComponent = component;
        string name = component.nameComponent;
        _textNameCell = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        _textNameCell.text = name;
        DragCell = dragCell;
    }
    public ComponentDefinition GetEntityComponent() => _curentComponent;

}
