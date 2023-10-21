using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    [SerializeField] GameObject carPrefab;
    [SerializeField] float carSpawnTime = 3f;
    [SerializeField] bool isRightToLeft;

    void Start() 
    {
        StartCoroutine(SpawnCars());    
    }

    IEnumerator SpawnCars()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(0, carSpawnTime));
            
            var car = Instantiate(carPrefab, transform.position, Quaternion.identity);
            if(isRightToLeft)
            {
                car.GetComponent<Car>().OpenRight();
            }
        }
    }

}
