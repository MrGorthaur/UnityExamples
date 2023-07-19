using UnityEngine;

[RequireComponent(typeof(PlayerIKAnimation))]
public class Player : MonoBehaviour
{
    private PlayerIKAnimation _animator;
    private Fruit _fruit;
    private Graber _graber;
    private Basket _basket;
    public GameTasks GameTasks { get; private set; }

    public void Init(GameTasks gameTasks)
    {
        GameTasks = gameTasks;
    }
    private void Awake() 
    {
        _animator = GetComponent<PlayerIKAnimation>();
        GameTasks.OnWin += Win;
    }
    private void Start()
    {
        _graber = GetComponentInChildren<Graber>();
        _basket = GetComponentInChildren<Basket>();
    }
    private void OnTriggerEnter(Collider other)
    {
        _fruit = other.GetComponent<Fruit>();
    }
    private void OnTriggerStay(Collider other)
    {
        if (_fruit.IsGrabed == true)
        {
            _animator.GrabTarget.position = _fruit.transform.position;
            _animator.GrabAnimation();
        }
    }
    private void Win()
    {
        _basket.gameObject.SetActive(false);
        _animator.WinAnimation();
    }
    public void PutInBasketAnimationEvent()
    {
        var spawnPoint = _basket.SpawnPoint;
        _graber.InstantiateGrabedObject(spawnPoint);
    }

}
