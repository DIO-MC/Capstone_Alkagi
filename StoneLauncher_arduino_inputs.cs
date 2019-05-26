using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Text;
using UnityEngine;
//using System.Diagnostics;

//code for ARDUINO datatypes
public class StoneLauncher : MonoBehaviour
{
    //USB PORT
    SerialPort serial = new SerialPort("/dev/cu.usbmodem1411101", 9600);
    //BLUETOOTH PORT
    //SerialPort serial = new SerialPort("/dev/cu.HC06STAND", 9600);
    string sensorvalue;
    //JAMDUINO datatypes

    float speed = 0;
    float final_speed;

    void Start()
    {
        Debug.Log("START!");
        serial.Open();
        serial.ReadTimeout = 1;
    }

    void Update()
    {
        if (!serial.IsOpen) serial.Open();
        Debug.Log("UPDATE!");
        if (serial.IsOpen)
        {
            Debug.Log("Serial is opened......!");
            try
            {
                sensorvalue = serial.ReadLine();
                Debug.Log("Which key is pressed?? " + sensorvalue + "!");

                //if (Input.GetKey(KeyCode.A))
                if (sensorvalue == "A")
                {
                    this.transform.Rotate(new Vector3(0, -1.0f, 0));
                    Debug.Log("좌회전");
                }
                //if (Input.GetKey(KeyCode.D))
                if (sensorvalue == "D")
                {
                    this.transform.Rotate(new Vector3(0, 1.0f, 0));
                    Debug.Log("우회전");
                }
                //if (Input.GetKey(KeyCode.H))
                if (sensorvalue == "H")
                {
                    Debug.Log("K is putting down...");
                    if (speed < 55)
                    {
                        speed += 0.3f;
                    }
                    final_speed = speed;
                    Debug.Log("final speed is " + final_speed);
                }

                //if (Input.GetKey(KeyCode.K))
                if (sensorvalue == "K")
                {
                    Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
                    speed = 0;
                    Debug.Log("Speed is initialized");
                    //Debug.Log("발사!!!");
                    this.GetComponent<Rigidbody>().velocity = forward.normalized * final_speed;
                    Debug.Log("final speed when H is " + final_speed);
                }
            }
            catch (System.Exception)
            {
                //Debug.Log("System.Exception occurred");
                throw;
            }
        }
    }
}
