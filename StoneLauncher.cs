using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using System.Text;
using UnityEngine;

public class StoneLauncher : MonoBehaviour
{

    //variables for ARDUINO

    //Vector3 originalPos;    //FOR TEST !! ^^
    SerialPort serial = new SerialPort("/dev/cu.usbmodem1431101", 9600);

    //public float amountToMove;
    float[] touchvalue = new float[5];
    float[] imuvalue = new float[9];
    string sensorvalue;

    //variables for ARDUINO


    protected LineRenderer line;
    protected MainStone mainstone;
    float speed = 0;

    // Start is called before the first frame update
    void Start()
    {
        line = FindObjectOfType<LineRenderer>();
        mainstone = FindObjectOfType<MainStone>();
    }

    // Update is called once per frame
    void Update()
    {
        /*여기부터 movecube */

        if (!serial.IsOpen) serial.Open();
        string sensorvalue = serial.ReadLine();
        Debug.Log(sensorvalue);

        string[] touchStr = new string[5];
        for (int i = 0; i < 4; i++)
        {
            int k = i * 10;
            k++;
            touchStr[i] = sensorvalue.Substring(sensorvalue.IndexOf('%') + k, 9);
        }
        touchStr[4] = sensorvalue.Substring(sensorvalue.IndexOf('%') + 41, 6);
        //Debug.Log(touchStr[3]);

        //convert string style sets of ascii to int arrays.
        //from thumb to ring finger
        int[] touchvalue = new int[] { 0, 0, 0, 0, 0 };
        byte[] asciiBytes;
        for (int j = 0; j < 4; j++)
        {
            asciiBytes = Encoding.ASCII.GetBytes(touchStr[j]);
            for (int i = 0; i < 9; i++)
                touchvalue[j] = touchvalue[j] + asciiBytes[i];
        }
        //smallest finger
        asciiBytes = Encoding.ASCII.GetBytes(touchStr[4]);
        for (int i = 0; i < 6; i++)
            touchvalue[4] = touchvalue[4] + asciiBytes[i];

        //convert sets of strings to float arrys.
        /*
        string imuStr = sensorvalue.Substring(sensorvalue.IndexOf('(') + 1, sensorvalue.IndexOf(')') - 1);
        string[] imuStrings = imuStr.Split(',');
        for (int i = 0; i < 9; i++) imuvalue[i] = float.Parse(imuStrings[i]);
        */

        //do something!
        // amountToMove = speed * Time.deltaTime;
        //LaunchObject(touchvalue);
        //Debug.Log(touchvalue);

        /*여기까지 movecube */



        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        var direction = Vector3.zero;

        if(Physics.Raycast(ray,out hit))
        {
            //Transform objectHit = hit.transform;
            var ballPosition = new Vector3(mainstone.transform.position.x, 0.1f, mainstone.transform.position.z);
            var mousePosition = new Vector3(hit.point.x, 0.1f, hit.point.z);
            line.SetPosition(0, ballPosition);
            line.SetPosition(1, mousePosition);
            direction = (mousePosition - ballPosition).normalized;
        }



        if (touchvalue[2] >= 450) //48('0' in ascii)*9(number of piaeces) + alpha(spare value: avoid error)
        {
            Debug.Log("MIDDLE finger putted...");
            if(speed < 555)
            {
                speed += 0.5f;
            }
        }
        else
        {
            Debug.Log("발사!!!");
            mainstone.GetComponent<Rigidbody>().velocity = direction * speed;
            Debug.Log("launched speed is " + speed);
            speed = 0;
            // Debug.Log("speed is initialized to zero~~!");
        }
        

        /* 
        if (Input.GetMouseButton(0))
        {//중지의 serial 넘버 기준으로 0의 갯수가 아닌 게 존재하는 시간동안 speed 증가, 모두 0일 때 발사!!, 이때 다시 0으로 초기화. float speed = 0 이용
            Debug.Log("Mouse button is putting down...");
            if(speed < 55)
            {
                speed += 0.3f;
            }

            // Debug.Log("gauged speed is " + speed);
        }
        if(Input.GetMouseButtonUp(0))
        {
            Debug.Log("발사!!!");
            mainstone.GetComponent<Rigidbody>().velocity = direction * speed;
            Debug.Log("launched speed is " + speed);
            speed = 0;
            // Debug.Log("speed is initialized to zero~~!");
        }
        */

    }

}

/*set frame rate low...*/