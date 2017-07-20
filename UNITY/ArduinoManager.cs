using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports; // necessary for serial communication

public class ArduinoManager : MonoBehaviour
{

  // create public variables accessible via the inspector
  [Tooltip("The serial port where the Arduino is connected")]
  public string port;

  [Tooltip("The baudrate of the serial port")]
  public int baud = 9600;

  public GameObject light;

  // create private variables
  private SerialPort stream;

  void Start()
  {
    stream = new SerialPort(port, baud); // define the connection to the serial port
    stream.ReadTimeout = 50; // set the timeout
    stream.Open(); // open the connection
    print("Serial Port connected");

  }

  public void WriteToArduino(string message)
  {
    stream.WriteLine(message + "\r\n"); // write the message to the stream
    stream.BaseStream.Flush(); // send all messages in the stream
    print("Wrote: " + message);
  }

  public string ReadFromArduino()
  {
    return stream.ReadLine();
  }

  void Update()
  {

    WriteToArduino("PING"); // query the arduino for sensor information

    string message = ReadFromArduino();
    print("Received: " + message); // log all received messages

    if (message.Split(':')[0] == "PONG")
    {

      if (light != null)
      {
        // change the light's rotation according to the photocell values
        light.transform.eulerAngles = new Vector3(
          scaleMap(
            float.Parse(message.Split(' ')[1]), 0f, 1024f, -50.0f, 50.0f
          ),
          scaleMap(
            float.Parse(message.Split(' ')[1]), 0f, 1024f, -50.0f, 50.0f
          ),
          light.transform.eulerAngles.z
        );

      }
    }

  }

  // map a value from one scale to another
  public float scaleMap(float OldValue, float OldMin, float OldMax, float NewMin, float NewMax)
  {

    float OldRange = (OldMax - OldMin);
    float NewRange = (NewMax - NewMin);
    float NewValue = (((OldValue - OldMin) * NewRange) / OldRange) + NewMin;

    return (NewValue);
  }
}
