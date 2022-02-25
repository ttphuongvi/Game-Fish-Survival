using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject fish;
    public float spawnTime = 1f;
    public int maxFish = 3, numFish = 0;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("createFish", spawnTime, spawnTime);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void createFish() {
        if (numFish < maxFish) {
            Instantiate(fish, transform.position, transform.rotation, GameObject.Find("Fishs").transform);    
            numFish++;
        }
          
    }
}
