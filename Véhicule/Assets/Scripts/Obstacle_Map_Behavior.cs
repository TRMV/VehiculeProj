using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Map_Behavior : MonoBehaviour
{
    Animator ObstAR;

    void Start()
    {
        ObstAR = gameObject.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        ObstAR.SetBool("Touched", true);
    }
    private void OnTriggerExit(Collider other)
    {
        ObstAR.SetBool("Touched", false);
    }
}
