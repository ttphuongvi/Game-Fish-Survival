using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject fish;
    public float spawnTime = 1f;
    public int maxFish = 3, numFish = 0;
    public float sizeMap = 7f, sizeScreen = 1.4f;

    public Vector3 spawnPosition;
    // Start is called before the first frame update
    void Start()
    {  
        spawnPosition = transform.position;
        spawnPosition.x = 1.4f;
        InvokeRepeating("createFish", spawnTime, spawnTime);
    }

    Vector3 RandomPosition(Vector3 position) {
        float x, y;
        do {
            x = Random.Range(-sizeMap, sizeMap);
            y = Random.Range(-sizeMap, sizeMap); 
        } while (!(-sizeMap < x && x < -sizeScreen && sizeScreen < x && x < sizeMap && -sizeMap < y && y < -sizeScreen && sizeScreen < y && y < sizeMap));
        position.x = x;
        position.y = y;
        return position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void createFish() {
        if (numFish < maxFish) {
            Instantiate(fish, spawnPosition, transform.rotation, GameObject.Find("Fishs").transform);    
            numFish++;
        }
          
    }
}
