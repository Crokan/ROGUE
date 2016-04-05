using UnityEngine;
using System.Collections;

public class DayData : MonoBehaviour
{

    float mDuration;
    

    void Start () {
	
	}
	
    void Update ()
    {
        mDuration += Time.deltaTime;
	}
}
