using System.Collections;
using System.Collections.Generic;
using PathCreation;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    public PathCreator pathCreator;

    public float speed = 5.0f;

    public float distanceTravelled;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distanceTravelled += speed * Time.deltaTime;
        transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled);
        Quaternion rotationAtDistance = pathCreator.path.GetRotationAtDistance(distanceTravelled);
        transform.rotation =  Quaternion.Euler(0, rotationAtDistance.y, 0);

        if (speed > 200)
        {
            speed = 200;
        }

        if (speed < -200)
        {
            speed = -200;
        }
        if (Input.GetKey("f"))
        {
            
            speed += 10 * Time.deltaTime;
        }

        if (Input.GetKey("s"))
        {
            speed = 10.0f * Time.deltaTime;
        }
        if(Input.GetKey("r"))
        {
            speed -= 10 * Time.deltaTime;
        }
    }
}
