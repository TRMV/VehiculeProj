using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boat_Behavior : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 5f;
    private int points;
    private int time;

    public Text scoretext;
    public Text timertext;

    public GameObject gameoverscreen;
    public Text gameovertext;
    private bool gameover;

    void Start()
    {
        points = 0;
        rb = gameObject.GetComponent<Rigidbody>();
        time = 60;

        StartCoroutine(Timer());
    }

    void Update()
    {
        timertext.text = time + "s";
        scoretext.text = points + "";
        

        if (time <= 0)
        {
            gameoverscreen.SetActive(true);
            gameover = true;
            gameovertext.text = "You saved " + points + " persons.";
        }
    }

    void FixedUpdate()
    {
        if (gameover == false)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                rb.velocity = -transform.right * speed * Time.deltaTime;
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                rb.velocity = transform.right * speed * Time.deltaTime;
            }
            else
            {
                rb.velocity = new Vector3(0, 0, 0);
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Rotate(new Vector3(0, -10, 0) * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Rotate(new Vector3(0, 10, 0) * Time.deltaTime);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Plane"))
        {
            points += Random.Range(10, 15);
            time += 30;
            StartCoroutine(PlaneDestroy(collision.transform.gameObject));
        }
    }

    private IEnumerator PlaneDestroy(GameObject plane)
    {
        speed += 5f;
        plane.GetComponent<BoxCollider>().isTrigger = true;
        plane.GetComponent<Rigidbody>().useGravity = true;
        yield return new WaitForSeconds(5f);
        Destroy(plane);
        speed -= 5f;
    }

    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(1f);
        if (gameover == false)
        {
            time--;
            StartCoroutine(Timer());
        }
    }
}
