using UnityEngine;
using System.Collections;

public class LookumaCamera : MonoBehaviour {

    Camera mCamera;

    public GameObject Kuma;

	// Use this for initialization
	void Start () {
        mCamera = GetComponent<Camera>();
        if (null == mCamera || null == Kuma)
        {
            return;
        }

        
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
