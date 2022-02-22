using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PhysicsEngine : MonoBehaviour
{

    // THE PHYSICS ENGINE uses standard SI units
    // RIGHT is forward (in the direction of the boat)

    public Transform propellerPosition;
    private Transform boatPosition;

    private bool shouldRunSimulation = false;

    // handle key input
    private KeyCode keyPressed;
    private bool wasKeyPressed;

    private Rigidbody rb;

    // vars to tweak
    // public float forwardForce = 100;
    // public float waterDragCoefficient = 0.345f; // unitless dimension, must be calculated experimently or using simulation software

    // store the boat
    private Body2D boat = new Body2D();


    // DISPLAY ONLY
    public Vector3 boatPositionDisp = Vector3.zero;
    public Quaternion boatRotationDisp = Quaternion.identity;
    public Vector3 boatVelocityDisp = Vector3.zero;
    public Vector3 boatAngularVelocityDisp = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        if(propellerPosition != null)
        {
            rb = GetComponent<Rigidbody>();

            // setup rb
            rb.isKinematic = true;

            shouldRunSimulation = true;
        }
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            keyPressed = KeyCode.W;
        } 
        else if (Input.GetKey(KeyCode.S))
        {
            keyPressed = KeyCode.S;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            keyPressed = KeyCode.A;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            keyPressed = KeyCode.D;
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            keyPressed = KeyCode.Space;
        }
        else
        {
            return;
        }

        wasKeyPressed = true;
    }

    // Update is called once per a fixed interval (used for physics)
    void FixedUpdate()
    {
        if (shouldRunSimulation)
        {
            // update
            // transfer data from unity into our physics engine
            boatPosition = transform;
            boat.position = boatPosition.position;
            boat.rotation = boatPosition.rotation;

            // handle key input
            if (wasKeyPressed)
            {
                if(keyPressed == KeyCode.W)
                {
                    boat.forces.Add(ForceUtil.CreateLinearForce(propellerPosition.position, -boatPosition.right.normalized));

                    // rb.AddForceAtPosition(-boatPosition.right.normalized * forwardForce, propellerPosition.position);
                }
                else if(keyPressed == KeyCode.S)
                {
                    boat.forces.Add(ForceUtil.CreateLinearForce(propellerPosition.position, boatPosition.right.normalized));
                    // boat.dynamicForces.Add(ForceUtil.CreateRelativeForce(propellerPosition.position, -(propellerPosition.rotation * Vector3.forward), propellerPosition.rotation));
                    // rb.AddForceAtPosition(boatPosition.right.normalized * forwardForce, propellerPosition.position);
                }
                else if(keyPressed == KeyCode.Space)
                {
                    boat.dynamicForces.Add(ForceUtil.CreateRelativeForce(propellerPosition.position, propellerPosition.rotation * Vector3.forward, propellerPosition.rotation));
                    // testing
                    DynamicForce force = ForceUtil.CreateRelativeForce(propellerPosition.position, propellerPosition.rotation * Vector3.forward, propellerPosition.rotation);
                    force.ResolveForce(boat);
                }
                else if (keyPressed == KeyCode.A)
                {
                    propellerPosition.Rotate(propellerPosition.up, 1);
                }
                else if (keyPressed == KeyCode.D)
                {
                    propellerPosition.Rotate(propellerPosition.up, -1);
                }


                wasKeyPressed = false;
            }

            boat.dynamicForces.Add(ForceUtil.CreateDragForce());

            // after applying all forces
            // update boat
            boat.UpdatePosition();

            transform.position = boat.position;
            transform.rotation = boat.rotation;

            DisplayData();
        }
    }

    private void DisplayData()
    {
        if (boat != null)
        {
            boatPositionDisp = boat.position;
            boatRotationDisp = boat.rotation;
            boatVelocityDisp = boat.velocity;
            boatAngularVelocityDisp = boat.angularVelocity;
        }
    }

}
