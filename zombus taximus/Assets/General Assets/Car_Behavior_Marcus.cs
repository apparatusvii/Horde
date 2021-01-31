using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_Behavior_Marcus : MonoBehaviour
{
    public GameObject wheel_1;
    public GameObject wheel_2;
    public GameObject wheel_3;
    public GameObject wheel_4;
    public GameObject Car_Body;
    public ParticleSystem Tire_Smoke_1;
    public ParticleSystem Tire_Smoke_2;

    public Rigidbody rb;
    private float Speed;
    public float Acceleration;
    public float JumpForce = 10;
    private float JumpStrength;
    public float Boost = 20;
    private float DriftBoost;
    private float tTime = 20;
    public AudioSource Car1;
    public AudioSource Car2;
    public AudioSource Car3;

    void start()
    {
      Car1.Play();
    }

    void wheelturn()
    {
      wheel_1.transform.Rotate(-Speed,0,0);
      wheel_2.transform.Rotate(-Speed,0,0);
      wheel_3.transform.Rotate(-Speed,0,0);
      wheel_4.transform.Rotate(-Speed,0,0);
      Car1.Play();

    }
    void turnL()
    {
    rb.transform.Rotate(0,5 * -1,0);
    rb.AddForce(0,-20,0, ForceMode.Impulse);

    }

    void turnR()
    {
      rb.transform.Rotate(0,5,0);
      rb.AddForce(0,-20,0, ForceMode.Impulse);

    }
    void Brake()
    {
      Speed = 0;
      Car1.Pause();

    }

    void FixedUpdate()

    {
        //Car Sounds
        if (Input.GetKeyDown("d") || Input.GetKeyDown("a"))
        {
          Car3.Play();
        }

        if (Input.GetKeyDown("s"))
        {
            Car2.Play();
        }



      //Car Controls
      if(Input.GetKey("s"))
      {
        Brake();

      }
      if(Input.GetKey("d"))
      {
        turnR();
      }

      if(Input.GetKey("a"))
      {
        turnL();
      }

      void activatesmoke()
      {

        Tire_Smoke_1.Play();
        Tire_Smoke_2.Play();
      }

      void deactivatesmoke()
      {
        Tire_Smoke_1.Stop();
        Tire_Smoke_2.Stop();
      }

      if( Input.GetKey("w") || Input.GetKey("d") || Input.GetKey("a"))
      {
        activatesmoke();
        Debug.Log("smoke on");
      }
      else if( !Input.GetKey("w") || !Input.GetKey("d") || !Input.GetKey("a"))
      {
        deactivatesmoke();
          Debug.Log("smoke off");
      }


      if (Input.GetKey("w"))  {
    Speed = Acceleration * Time.deltaTime * tTime;
    rb.AddForce(transform.forward * Speed);
    }
    else


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
      if(Input.GetKey("w"))
     Debug.Log("Accelerating");
     {

       wheelturn();

   }


  //  if(Input.GetKey("left shift"))
    {
      //driftingfunction();
    }

//void driftingfunction()
{
//Debug.Log("Boing");
// rb.AddForce(0,JumpStrength,0,  ForceMode.Impulse);
 //JumpStrength = JumpForce * Time.deltaTime;
//  rb.transform.Rotate (0,3,0);
//  wheel_1.transform.Rotate(0,0,Speed);
//  wheel_2.transform.Rotate(0,0,Speed);
//  wheel_3.transform.Rotate(0,0,Speed);
// wheel_4.transform.Rotate(0,0,Speed);
  //rb.AddForce(transform.forward * -1 * DriftBoost);
}


    }
}
