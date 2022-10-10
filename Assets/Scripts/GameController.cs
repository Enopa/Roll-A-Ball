using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class GameController : MonoBehaviour
{
    //Debuggin
    public GameObject player; 
    public GameObject position;
    public GameObject velocity;
    private Vector3 oldPos;

    public GameObject[] pickups;

    enum Debug
    {
        None,
        Distance,
        Vision
    }
    Debug debug = Debug.None;
    private LineRenderer lineRenderer;

    // Start is called before the first frame update
    void Start()
    {
        oldPos = player.transform.position;
    }

    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            switch(debug)
            {
                case Debug.None:
                    position.gameObject.SetActive(true);
                    velocity.gameObject.SetActive(true);
                    debug = Debug.Distance;
                    break;
                case Debug.Distance:
                    lineRenderer = gameObject.AddComponent<LineRenderer>();
                    debug = Debug.Vision;
                    break;
                case Debug.Vision:
                    position.gameObject.SetActive(false);
                    velocity.gameObject.SetActive(false);
                    Destroy(lineRenderer);
                    debug = Debug.None;
                    break;
            }
        }

        if (debug == Debug.Vision)
        {
            lineRenderer.SetPosition(0, player.transform.position);
            lineRenderer.SetPosition(1, player.GetComponent<Rigidbody>().velocity);
            lineRenderer.startWidth = 0.1f;
            lineRenderer.endWidth = 0.1f;
        }

        position.GetComponent<TextMeshProUGUI>().text = player.transform.position.ToString();
        velocity.GetComponent<TextMeshProUGUI>().text = (oldPos - player.transform.position).ToString();
        oldPos = player.transform.position;
    }
}
