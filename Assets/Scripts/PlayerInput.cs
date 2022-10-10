using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class PlayerInput : MonoBehaviour
{
    //Movement Stuff
    public Vector2 moveValue;
    public float speed;

    //ScoreStuff
    [SerializeField]
    private int count;
    private int numPickups = 8;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI winText;

    void OnMove(InputValue value)
    {
        moveValue = value.Get<Vector2>();
    }

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        winText.text = "";
        SetCountText();
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
            SetCountText();
        }
    }

    private void SetCountText()
    {
        scoreText.text = "Score: " + count.ToString();
        if(count >= numPickups)
        {
            winText.text = "You Win!";
        }
    }
}
