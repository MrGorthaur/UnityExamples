using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    [SerializeField] private float _speed = 1.5f;
    [SerializeField] private Transform _startPoint;
    [SerializeField] private Transform _endPoint;
    [SerializeField] private Conveyor _conveyor;
    [SerializeField] private GameObject[] _prefabObjects;
    [SerializeField] private Player _player;
    [SerializeField] private Basket _basket;
    [SerializeField] private CanvasManager _canvasManager;
    [SerializeField] private CameraManager _cameraManager;

    private GameTasks _gameTasks;

    private void Awake()
    {
        _gameTasks = new GameTasks(_prefabObjects,_basket);
        _conveyor.Init(_prefabObjects, _startPoint.position, _endPoint.position, _speed,_gameTasks);
        _player.Init(_gameTasks);
        _basket.Init(_gameTasks);
        _canvasManager.Init(_gameTasks,_basket);
        _cameraManager.Init(_gameTasks);
    }
}

