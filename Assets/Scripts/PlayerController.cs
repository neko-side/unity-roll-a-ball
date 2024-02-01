using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public TextMeshProUGUI countText;
    public GameObject winText;
    
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    private int count;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.SetActive(false);
    }
    
    private void FixedUpdate()
    {
        Vector3 move = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(move * speed);
    }
    
    private void OnMove(InputValue movement)
    {
        Vector2 moveVector = movement.Get<Vector2>();
        movementX = moveVector.x;
        movementY = moveVector.y;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("PickUp"))
            return;
        other.gameObject.SetActive(false);
        count++;
        SetCountText();
    }

    private void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count < 9)
            return;
        winText.SetActive(true);
    }
}
