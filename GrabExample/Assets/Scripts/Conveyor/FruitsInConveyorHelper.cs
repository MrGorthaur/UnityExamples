using UnityEngine;

public class FruitsInConveyorHelper
{
    public void MoveFruitsByCollider(Collider other, Vector3 endPosition, float speed)
    {
        if (other.CompareTag("Fruit"))
        {
            other.transform.position =
            Vector3.MoveTowards(other.transform.position, endPosition, speed * Time.deltaTime);
        }

        if (other.transform.position == endPosition)
            GameObject.Destroy(other.gameObject);
    }
    public void CreateFruit(GameObject[] prefabObjects, Vector3 startPoint)
    {
        int generateCount = Random.Range(0, prefabObjects.Length);
        var fruit = GameObject.Instantiate(prefabObjects[generateCount], startPoint, Quaternion.identity);
        fruit.AddComponent<Rigidbody>();
        fruit.AddComponent<BoxCollider>();
        fruit.AddComponent<Fruit>();
    }
}

