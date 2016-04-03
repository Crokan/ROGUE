using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public GameObject Model;
    public float MoveSpeed;
    public Camera MainCamera;

	void Start ()
    {
	
	}
	
	void Update ()
    {
        RaycastHit hit;
        Ray ray = MainCamera.ScreenPointToRay(Input.mousePosition);
        
        Debug.DrawLine(ray.origin, ray.origin + ray.direction * 100);

        if (Physics.Raycast(ray, out hit))
        {
            Transform objectHit = hit.transform;
            Vector3 start = transform.position;
            Vector3 goal = hit.transform.position;
            start.y = 0.0f;
            goal.y = 0.0f;

            transform.position += (goal - start).normalized * MoveSpeed * Time.deltaTime;

            // Do something with the object that was hit by the raycast.
        }

	}
}
