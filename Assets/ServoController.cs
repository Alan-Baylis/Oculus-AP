using UnityEngine;
using VR = UnityEngine.VR;
using System.Collections;
using System;
using System.IO;
using System.IO.Pipes;
using System.Text;
using System.Net.Sockets;

public class ServoController : MonoBehaviour {
    String hostIP = "localhost";
    int hostPort = 9874;

    UdpClient socket;

    int BOT_CHAN = 0;
    int BOT_MID = 5500;

    int TOP_CHAN = 1;
    int TOP_MID = 6500;

	// Use this for initialization
	void Start () {
        socket = new UdpClient(hostPort);
        socket.Connect(hostIP, hostPort);

        System.Diagnostics.ProcessStartInfo start = new System.Diagnostics.ProcessStartInfo();
        string path = System.IO.Path.GetFullPath(".");
        start.FileName = @"C:\Python27\python.exe";
        start.Arguments = string.Format("{0}\\Assets\\servo.py", path);
        start.CreateNoWindow = true;
        start.UseShellExecute = false;
        start.RedirectStandardOutput = true;
        start.RedirectStandardError = true;
        start.WorkingDirectory = path;

        System.Diagnostics.Process process = System.Diagnostics.Process.Start(start);
        //Debug.Log(process.StandardOutput.ReadToEnd());
        //Debug.Log(process.StandardError.ReadToEnd());

        moveServo(BOT_CHAN, BOT_MID);
        moveServo(TOP_CHAN, TOP_MID);
	}

    void moveServo(int chan, int pos) {
        byte[] buffer = ASCIIEncoding.ASCII.GetBytes(String.Format("({0}, {1})", chan, pos));
        socket.Send(buffer, buffer.Length);
    }

    // Update is called once per frame
    void Update () {
        var gyro = Camera.main.transform.forward;
        moveServo(BOT_CHAN, (int)(gyro.y * 2000) + BOT_MID);
        moveServo(TOP_CHAN, (int)((-1 * gyro.x) * 2000) + TOP_MID);
        //Debug.Log(string.Format("Y Value: {0} X Value: {1}", (int)(gyro.y * 1700) + BOT_MID, (int)(gyro.x * 2000) + TOP_MID));

    }

    void OnApplicationQuit() {
        moveServo(-1, 0);
        socket.Close();
    }
}
