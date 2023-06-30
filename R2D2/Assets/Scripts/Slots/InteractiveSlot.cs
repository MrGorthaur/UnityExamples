using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class InteractiveSlot : MonoBehaviour, IPointerClickHandler
{
    private Image _deffaultImg;
    private Sprite _deffaultSprite;
    private RectTransform _rect;

    Vector3 closeAngle;
    Vector3 openAngle;
    public void Init(ISlotSpritesData spriteData)
    {
        _deffaultSprite = spriteData.DeffaultSprite;
    }
    private void Start()
    {

        _deffaultImg = GetComponent<Image>();
        _rect = GetComponent<RectTransform>();
        _deffaultImg.sprite = _deffaultSprite;
        closeAngle = new Vector3(90, 0, 0);
        openAngle = new Vector3(0, 0, 0);
        _rect.Rotate(closeAngle);
        StartCoroutine(ActivateGameObject(3));
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        gameObject.SetActive(false);
    }
    private IEnumerator ActivateGameObject(float delay)
    {
        yield return new WaitForSeconds(delay);
        _rect.rotation = Quaternion.identity;
        Debug.Log("Corutine is work");
    }


}
