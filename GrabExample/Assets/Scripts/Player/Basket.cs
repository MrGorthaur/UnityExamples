using System;
using UnityEngine;

public class Basket : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    private Fruit _fruit;
    private GameTasks _gameTasks;

    public Transform SpawnPoint => _spawnPoint;

    public Action<int> OnTaskAmountChanged;
    public Action<string> OnTaskNameChanged;

    public void Init(GameTasks gameTasks)
    {
        _gameTasks = gameTasks;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out _fruit))
        {
            if (_gameTasks.Name == other.name)
            {
                OnTaskAmountChanged?.Invoke(1);
                OnTaskNameChanged?.Invoke(other.name);
            }
            else 
            {
                Destroy(other.gameObject);
                Debug.Log("Incorect fruit");
            }
        }
    }




}
