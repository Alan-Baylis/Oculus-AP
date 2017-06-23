using UnityEngine;
using System.Collections;

public class FrameRateUnlocked : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Awake();
    }

    void Awake() {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 2;
    }

    // Update is called once per frame
    void Update () {
        //Awake();
    }


}
