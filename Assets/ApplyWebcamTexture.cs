using UnityEngine;
using VR = UnityEngine.VR;
using System.Collections;

public class ApplyWebcamTexture : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Debug.Log("Initialize");
        Renderer renderer = gameObject.GetComponent<Renderer>();
        //set up camera
        WebCamDevice[] devices = WebCamTexture.devices;
        string backCamName = "";
        for (int i = 0; i < devices.Length; i++)
        {
            Debug.Log("Device: " + devices[i].name + " IS FRONT FACING: " + devices[i].isFrontFacing);

            if (devices[i].isFrontFacing)
            {
                backCamName = devices[i].name;
            }
        }

        var CameraTexture = new WebCamTexture(backCamName, 1920, 1080, 90);
        renderer.material.mainTexture = CameraTexture;
        renderer.material.shader = Shader.Find("Sprites/Default");
        CameraTexture.Play();
    }

	// Update is called once per frame
	void Update () {

    }
}
