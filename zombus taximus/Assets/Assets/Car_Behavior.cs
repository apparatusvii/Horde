using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_Behavior : MonoBehaviour
{
    public GameObject wheel_1;
    public GameObject wheel_2;
    public GameObject wheel_3;
    public GameObject wheel_4;
    public GameObject Car_Body;
    public Rigidbody rb;
    private float Speed;
    public float Acceleration;
    public float JumpForce = 10;
    private float JumpStrength;
    private bool drifthit = true;
    public float drifthitresettime = 5;
    private float drifthitreset;
    public float Boost = 20;
    private float DriftBoost;


    void FixedUpdate()
    {
      if (Input.GetKey("space"))  {
    Speed = Acceleration * Time.deltaTime;
    rb.AddForce(transform.forward * Speed);
    }
    else
    {
      Speed = 0;
    }
    if (Input.GetKey("left shift"))
    {
      DriftBoost = Acceleration * Boost * Speed;

    }
    else
    {
      DriftBoost = 0;
    }
  }




    void Update()
    {
      if(Input.GetKey("space"))
     Debug.Log("Accelerating");
     {

     wheel_1.transform.Rotate(0,0,Speed);
     wheel_2.transform.Rotate(0,0,Speed);
     wheel_3.transform.Rotate(0,0,Speed);
     wheel_4.transform.Rotate(0,0,Speed);

   }


    if(Input.GetKey("left shift") && drifthit)
    {
      Debug.Log("Boing");
      rb.AddForce(0,JumpStrength,0,  ForceMode.Impulse);
      JumpStrength = JumpForce * Time.deltaTime;
      rb.transform.Rotate (0,1,0);
      wheel_1.transform.Rotate(0,0,Speed);
      wheel_2.transform.Rotate(0,0,Speed);
      wheel_3.transform.Rotate(0,0,Speed);
      wheel_4.transform.Rotate(0,0,Speed);

      rb.AddForce(transform.forward * -1 * DriftBoost);
      drifthitreset = drifthitresettime - Time.deltaTime * Speed;

      Debug.Log(drifthitreset);
    }



    }
}
