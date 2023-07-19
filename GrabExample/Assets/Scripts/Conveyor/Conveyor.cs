using System.Collections;
using UnityEngine;

public class Conveyor : MonoBehaviour
{
    private float _speed;
    private Vector3 _startPosition;
    private Vector3 _endPosition;
    private GameObject[] _fruitPrefabs;
    private FruitsInConveyorHelper _fruitOperations;
    private Material _material;
    private GameTasks _gameTasks;
    public void Init(
        GameObject[] fruitPrefabs,
        Vector3 startPosition,
        Vector3 endPosition,
        float speed,
        GameTasks gameTasks)
    {
        _fruitPrefabs = fruitPrefabs;
        _startPosition = startPosition;
        _endPosition = endPosition;
        _speed = speed;
        _fruitOperations = new FruitsInConveyorHelper();
        _gameTasks = gameTasks;
    }
    private void Start()
    {
        var renderer = GetComponent<Renderer>();
        _material = renderer.material;
        _gameTasks.OnWin += Win;
        StartCoroutine(GenerateFruits());
    }

    private void Win()
    {
        gameObject.SetActive(false);
    }

    private void Update()
    {
        _material.SetTextureOffset("_MainTex", new Vector2(-0.1f * Time.time, 0));
    }
    private void OnTriggerStay(Collider other)
    {
        _fruitOperations.MoveFruitsByCollider(other, _endPosition, _speed);
    }
    private void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
    }
    private IEnumerator GenerateFruits()
    {
        _fruitOperations.CreateFruit(_fruitPrefabs, _startPosition);
        yield return new WaitForSeconds(2f);
        StartCoroutine(GenerateFruits());
    }
    private void OnDisable()
    {
        _gameTasks.OnWin -= Win;
    }

}
