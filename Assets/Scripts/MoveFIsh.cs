using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFIsh : MonoBehaviour
{
    public float moveSpeed = 1;
    public bool leftDirection = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float directionKey = Input.GetKey(KeyCode.A) ? -1 : (Input.GetKey(KeyCode.D) ? 1 : 0);
        float y = Input.GetKey(KeyCode.S) ? -1 : (Input.GetKey(KeyCode.W) ? 1 : 0);

        if ((directionKey == -1 && !leftDirection) || (directionKey == 1 && leftDirection))
            transform.Rotate(0, 180, 0, Space.World);

        if (directionKey == -1)
            leftDirection = true;
        else if (directionKey == 1)
            leftDirection = false;


        Vector3 pos = new Vector3(-Mathf.Abs(directionKey), y, 0);
        transform.Translate(pos * moveSpeed * Time.deltaTime);  
    }
}
