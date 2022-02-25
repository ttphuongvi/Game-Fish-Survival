using UnityEngine;
 using System.Collections;
 
 public class MouseControl : MonoBehaviour {
 
     // Mouse Control Variabbles
     public float mouseSensitivityX = 1;
     public float mouseSensitivityY = 1;
     
     
     // Use this for initialization
     void Start () {
     
     }
     
     // Update is called once per frame
     void Update () {
         
         float moveLR = Input.GetAxis("Mouse X") * mouseSensitivityX * Time.deltaTime;
         float moveUD = Input.GetAxis("Mouse Y") * mouseSensitivityY * Time.deltaTime;
         
         Vector3 mouse = Camera.main.ScreenToViewportPoint(Input.mousePosition);
         transform.position = new Vector3(mouse.x, mouse.y, transform.position.z);
     }
 }
 