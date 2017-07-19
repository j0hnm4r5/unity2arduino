using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{

  public GameObject ArduinoManager;

  void OnCollisionEnter()
  {

    // randomly change the target's color whenever it is hit
    GetComponent<Renderer>().material.SetColor("_Color", new Color(Random.value, Random.value, Random.value));

    if (ArduinoManager != null)
    {
      // access the Arduino Manager's copy of the ArduinoManager, and write to the arduino
      ArduinoManager.GetComponent<ArduinoManager>().WriteToArduino("BOOM");
    }

  }
}
