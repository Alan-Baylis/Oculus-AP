using UnityEngine;
using System.Collections;

public class MoveWithCamera : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Transform item = gameObject.GetComponent<Transform>();
        item.up = -item.up;
    }

	// Update is called once per frame
	void Update () {
        /*Transform item = gameObject.GetComponent<Transform>();
        Vector3 pos = Camera.main.WorldToViewportPoint(item.position);
        //item.up = gyro.forward;
        //item.position = gyro.position + (gyro.forward * 5000);
        pos.x = Mathf.Clamp01(pos.x + 10);
        pos.y = Mathf.Clamp01(pos.y + 10);
        pos.z = Mathf.Clamp01(pos.z + 10);
        item.position = Camera.main.ViewportToWorldPoint(pos);*/
    }
}
