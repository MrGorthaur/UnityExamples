using UnityEngine;

public delegate void Win();
public class GameTasks
{
    private GameObject[] _fruitPrefabs;
    private Basket _basketListener;

    public event Win OnWin;

    public int Amount { get; private set; }
    public string Name { get; private set; }
    public string GameTask => $"Collect: {Amount} {Name}'s";

    public GameTasks(GameObject[] fruitPrefabs, Basket basket)
    {
        _fruitPrefabs = fruitPrefabs;
        _basketListener = basket;
        GenerateTask();
        _basketListener.OnTaskAmountChanged += TaskChanged;
    }
    private void TaskChanged(int amount)
    {
        Amount -= amount;
        if (Amount == 0)
        {
            OnWin?.Invoke();
        }
    }
    public void GenerateTask()
    {
        int randomName = Random.Range(0, _fruitPrefabs.Length);
        Amount = Random.Range(3, _fruitPrefabs.Length);
        Name = _fruitPrefabs[randomName].name;
    }
}

