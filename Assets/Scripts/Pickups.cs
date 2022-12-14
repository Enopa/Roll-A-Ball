using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{
    [SerializeField]
    private int rotSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime * rotSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PickUp")
        {
                other.gameObject.SetActive(false);
        }
    }
}
