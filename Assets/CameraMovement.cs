using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

	public Transform target;
	public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
     
	 
    }
 void Update()
 {
	transform.position = new Vector3 (target.position.x + offset.x, target.position.y + offset.y, offset.z);
 }
}