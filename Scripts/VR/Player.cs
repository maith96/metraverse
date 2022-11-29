using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float rotSpeed;

     float _rotationY;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float rotDirection = Input.GetAxis("Horizontal");
        _rotationY += rotSpeed* rotDirection * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0,  _rotationY, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ElephantPack"))
        {
            Debug.Log("Enter");

            other.GetComponent<PackElephant>().spawn = true;
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        
        if (other.CompareTag("ElephantPack"))
        {
            //Debug.Log("Exit");
            other.GetComponent<PackElephant>().deSpawn = true;
        }
    }
}
