using UnityEngine;

public class Graber : MonoBehaviour
{
    public GameObject FruitObject { get; private set; }
    private Fruit _fruit;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out _fruit))
        {
            Destroy(other.GetComponent<Rigidbody>());
            Destroy(other.GetComponent<BoxCollider>());
            other.transform.SetParent(transform);
            FruitObject = other.gameObject;
        }
    }
    public void InstantiateGrabedObject(Transform spawnTransform)
    {
        if(FruitObject != null)
        {
            FruitObject.AddComponent<Rigidbody>();
            FruitObject.AddComponent<SphereCollider>();
            FruitObject.GetComponent<Rigidbody>().mass = 20;
            Instantiate(FruitObject, spawnTransform.position, Quaternion.identity);
            Destroy(FruitObject);
        }
    }
}
