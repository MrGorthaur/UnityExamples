using System.Collections;
using TMPro;
using UnityEngine;


public class CanvasManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _taskText;
    [SerializeField] private TMP_Text _collectableText;
    [SerializeField] private GameObject _winPanel;

    private Animator _canvasAnimator;
    private GameTasks _gameTasks;
    private Basket _basket;
    public void Init(GameTasks gameTasks, Basket basket)
    {
        _gameTasks = gameTasks;
        _basket = basket;
    }
    private void Start()
    {
        _canvasAnimator = GetComponentInParent<Animator>();
        _gameTasks.OnWin += ActivateWinPanel;
        _basket.OnTaskNameChanged += CollectedFruitTextCoroutine;
    }
    private void FixedUpdate()
    {
        _taskText.text = _gameTasks.GameTask;
    }
    private void OnDisable()
    {
        _basket.OnTaskNameChanged -= CollectedFruitTextCoroutine;
        _gameTasks.OnWin -= ActivateWinPanel;
    }
    public void CollectedFruitTextCoroutine(string fruitName)
    {
        StartCoroutine(TextCollected(fruitName));
    }
    public IEnumerator TextCollected(string fruitName)
    {
        _collectableText.gameObject.SetActive(true);
        _collectableText.text = $"Collected {fruitName}";
        _canvasAnimator.SetTrigger("Collect");
        yield return new WaitForSeconds(1);
        _collectableText.gameObject.SetActive(false);
    }
    private void ActivateWinPanel()
    {
        _winPanel.SetActive(true);
    }
}
