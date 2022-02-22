using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMove : MonoBehaviour
{
    public float moveSpeed = 1;
    public int x = 0, y = 0;
    public bool leftDirection = true;

    // Start is called before the first frame update
    void Start()
    {
        leftDirection = (Random.value < 0.5f) ? true : false;
    }

    void updateMove() {
        x = Random.Range(-1, 2); // -1 left, 0 none, 1 right
        y = Random.Range(-1, 2); // -1 up, 0 none, 1 down
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = new Vector3(-Mathf.Abs(x), y, 0);
        transform.Translate(pos * moveSpeed * Time.deltaTime);  
    }
}
