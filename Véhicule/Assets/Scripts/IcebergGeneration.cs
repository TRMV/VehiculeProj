using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcebergGeneration : MonoBehaviour
{
    public GameObject boat;

    public GameObject icePrefab;
    public GameObject[] iceList;
    public GameObject spawnpoint;

    void Update()
    {
        transform.position = boat.transform.position;
    }

    /*private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            for (int i = 0; i < iceList.Length; i++)
            {
                if (iceList[i] == collision.transform.gameObject)
                {
                    iceList[i] = collision.transform.gameObject;
                }
            }
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            for (int i = 0; i < iceList.Length; i++)
            {
                if (iceList[i] == null)
                {
                    iceList[i] = null;
                    StartCoroutine(GenerateIceberg());
                }
            }
        }
    }

    private IEnumerator GenerateIceberg()
    {
        yield return new WaitForSeconds(2f);

        for (int i = 0; i < iceList.Length; i++)
        {
            if (iceList[i] == null)
            {
                GameObject newIce = Instantiate(icePrefab, spawnpoint.transform.position, transform.rotation);
                iceList[i] = newIce.transform.gameObject;
            }
        }
    }*/

}
