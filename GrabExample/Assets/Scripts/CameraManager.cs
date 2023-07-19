using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Transform _cameraWinTransform;
    private GameTasks _gameTasks;

    public void Init(GameTasks gameTasks)
    {
        _gameTasks = gameTasks;
        _gameTasks.OnWin += Win;
    }
    private void Win()
    {
        _camera.transform.position = Vector3.MoveTowards(
            _camera.transform.position,
            _cameraWinTransform.position,
            1);
    }
    private void OnDisable()
    {
        _gameTasks.OnWin -= Win;
    }
}
