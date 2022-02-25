using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFish : MonoBehaviour
{
    public float moveSpeed = 0.2f;
    public bool leftDirection = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float directionKey = (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) ? -1 : (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) ? 1 : 0);
        float y = Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow) ? -1 : (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) ? 1 : 0);

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
