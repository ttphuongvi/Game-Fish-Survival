using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMove : MonoBehaviour
{
    public float moveSpeed = 0.1f;
    public int x = 0, y = 0;
    public bool leftDirection = true;
    public float updateTime = 2;

    // Start is called before the first frame update
    void Start()
    {
        leftDirection = (Random.value < 0.5f) ? true : false;
        if (!leftDirection)
            transform.Rotate(0, 180, 0, Space.World);

        InvokeRepeating("updateMove", updateTime, updateTime);
    }

    void updateMove() {
        x = Random.Range(-1, 2); // -1 left, 0 none, 1 right
        y = Random.Range(-1, 2); // -1 up, 0 none, 1 down

        
        UpdateDirection(leftDirection, x);
    }

    void UpdateDirection(bool realDirection, float futureDirection) {
        if ((futureDirection == -1 && !realDirection) || (futureDirection == 1 && realDirection))
            transform.Rotate(0, 180, 0, Space.World);

        if (futureDirection == -1)
            realDirection = true;
        else if (x == 1)
            realDirection = false;
    }

    void UpdatePosition(float x, float y) {
        Vector3 pos = new Vector3(-Mathf.Abs(x), y, 0);
        transform.Translate(pos * moveSpeed * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePosition(x, y);
    }
}
