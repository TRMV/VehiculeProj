using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject boat;
    public GameObject avionPrefab;

    public bool hasSpawn;

    private void Start()
    {
        GameObject AvionClone = Instantiate(avionPrefab, transform.position, transform.rotation);
        hasSpawn = true;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player") || hasSpawn == true)
        {
            hasSpawn = false;
            StartCoroutine(Spawner());
        }
    }

    private IEnumerator Spawner()
    {
        yield return new WaitForSeconds(35f);
        hasSpawn = true;
        GameObject AvionClone = Instantiate(avionPrefab, transform.position, transform.rotation);
    }
}
