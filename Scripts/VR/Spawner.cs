using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Spawner : MonoBehaviour
{
    public GameObject animal;
    public int numOfAnimals = 1;
    public int radius = 100;
    

    private List<GameObject> _animals = new List<GameObject>();

    private GameObject newAnimal;

    private Vector3 _position;

    public bool spawn = false;
    public bool deSpawn = false;
    // Start is called before the first frame update
    void Start()
    {
        _position = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (spawn)
        {
           SpawnRhns();
           spawn = false;
        }

        if (deSpawn)
        {
            DeSpawn();
            deSpawn = false;
        }
    }

    private void SpawnRhns()
    {
        for (int i = 0; i < numOfAnimals; i++)
        {
            newAnimal = Instantiate(animal, new Vector3((Random.Range(0,20) + _position.x), 0, (Random.Range(0,20) + _position.z) ), Quaternion.Euler(-90, Random.Range(-160, 160), 0)) ;
            if(newAnimal) _animals.Add(newAnimal);
        }
    }

    private void DeSpawn()
    {
        int lastIndex = _animals.Count - 1;
        Destroy(_animals[lastIndex]);
        _animals.RemoveAt(lastIndex);
    }
}
