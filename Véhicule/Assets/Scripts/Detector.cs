using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour
{
    public AudioSource aS;
    public float speed;

    void Update()
    {
        transform.Rotate(new Vector3(0, speed, 0) * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {  
        if (other.CompareTag("Obstacle"))
        {
            StartCoroutine(Bip(other.gameObject));
        }

        if (other.CompareTag("Plane"))
        {
            aS.Play();
            StartCoroutine(Bip(other.gameObject));
        }
    }

    IEnumerator Bip(GameObject hitObject)
    {
        hitObject.GetComponent<Animator>().SetBool("Touched", true);
        yield return new WaitForSeconds(0.1f);
        hitObject.GetComponent<Animator>().SetBool("Touched", false);
    }
}
