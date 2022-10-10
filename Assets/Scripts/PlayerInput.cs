using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{

    public Vector2 moveValue;
    public float speed;
    [SerializeField]
    private int count;

    void OnMove(InputValue value)
    {
        moveValue = value.Get<Vector2>();
    }

    // Start is called before the first frame update
    void Start()
    {
        count = 0;   
    }

    // Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate() {
        Vector3 movement = new Vector3(moveValue.x, 0.0f, moveValue.y);
        GetComponent<Rigidbody>().AddForce(movement * speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PickUp")
        {
            other.gameObject.SetActive(false);
            count++;
        }
    }
}
