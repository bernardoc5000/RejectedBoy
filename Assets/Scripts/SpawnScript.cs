using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour {

    public GameObject[] obj;
    public float spawnTimeMin = 1f;
    public float spawnTimeMax = 2f;

	// Use this for initialization
	void Start () {
        Spawn();
	}

    void Spawn()
    {
        Instantiate(obj[Random.Range(0, obj.Length)], transform.position, Quaternion.identity);
        Invoke("Spawn", Random.Range(spawnTimeMin, spawnTimeMax));
    }
}
