using UnityEngine;
using UnityEngine.EventSystems;

public class Fruit : MonoBehaviour, IPointerClickHandler
{
    private Rigidbody _rigidbody;
    public bool IsGrabed { get; set; }
    private void Awake()
    {
        gameObject.name = gameObject.name.Substring(0, gameObject.name.Length - 7);
    }
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        IsGrabed = true;
    }
}
