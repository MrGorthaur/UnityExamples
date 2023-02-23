using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Conveyor : MonoBehaviour
{
    [SerializeField] Transform StartPoint;
    [SerializeField] GameObject[] prefabObjects;
    public GameObject fruit;

    private void Start()
    {
        StartCoroutine(GenerateFruits());
    }

    void CreateRandomFruit(){
        int generateCount = Random.Range(0, prefabObjects.Length);
        fruit = Instantiate(prefabObjects[generateCount], StartPoint.position, Quaternion.identity);
        fruit.AddComponent<Rigidbody>();
        fruit.AddComponent<BoxCollider>();
        
    }
    IEnumerator GenerateFruits(){
        CreateRandomFruit();
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(GenerateFruits());
    }
   
    
}





