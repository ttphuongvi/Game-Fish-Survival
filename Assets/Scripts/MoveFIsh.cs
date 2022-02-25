using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFish : MonoBehaviour
{
    public float moveSpeed = 0.2f;
    public bool leftDirection = true;

    // Key control
    private bool isKeyDown = true;
    // Mouse Control Variabbles
    private float deltaX, deltaY, maxRatio = 1f;




    // Start is called before the first frame update
    void Start()
    {

    }

    void UpdateByKey()
    {
        float directionKey = (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) ? -1 : (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) ? 1 : 0);
        float y = Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow) ? -1 : (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) ? 1 : 0);
        isKeyDown = (directionKey == 0 && y == 0 ? false : true);

        if ((directionKey == -1 && !leftDirection) || (directionKey == 1 && leftDirection))
            transform.Rotate(0, 180, 0, Space.World);

        if (directionKey == -1)
            leftDirection = true;
        else if (directionKey == 1)
            leftDirection = false;

        Vector3 pos = new Vector3(-Mathf.Abs(directionKey), y, 0);
        transform.Translate(pos * moveSpeed * Time.deltaTime);
    }

    void UpdateByMouse()
    {
        Vector2 mouse = Input.mousePosition;
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(mouse.x, mouse.y, 1f));
        // Get position mouse in world

        deltaX = mousePosition.x - transform.position.x;
        deltaY = mousePosition.y - transform.position.y;
        if (deltaX < 0 && !leftDirection) {
            transform.Rotate(0, 180, 0, Space.World);
            leftDirection = true;
        } else if (deltaX > 0 && leftDirection) {
            transform.Rotate(0, 180, 0, Space.World);
            leftDirection = false;
        }

        float tempX = Mathf.Abs(deltaX), tempY = Mathf.Abs(deltaY);
        if (tempX < 0.1 && tempY < 0.05)
            return;
        // threshold to return

        if (tempX > tempY) {
            deltaX = maxRatio;
            deltaY = deltaY * maxRatio / tempX;
        } else {
            deltaY = maxRatio * (deltaY < 0 ? -1 : 1);
            deltaX = tempX * maxRatio / tempY;
        }
        // calcula x, y
        Vector3 pos  = new Vector3(-deltaX, deltaY, 0);
        transform.Translate(pos * moveSpeed * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateByKey();
        if (!isKeyDown)
            UpdateByMouse();


    }
}
