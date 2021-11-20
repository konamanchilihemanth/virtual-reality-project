using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform groungCheckTransform = null;
    [SerializeField] LayerMask playerMask;

    bool jumpKeywasPressed = false;
    float horizontalInput, verticalInput;
    float translateSpeedFactor = 0.4f;
    Rigidbody rigidbodyComponent;

    // Start is called before the first frame update
    void Start()
    {
        rigidbodyComponent = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpKeywasPressed = true;
        }

        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.forward * verticalInput * translateSpeedFactor);

        transform.Rotate(Vector3.up * horizontalInput);

        if (Physics.OverlapSphere(groungCheckTransform.position, 0.1f, playerMask).Length == 0)
        {
            return;
        }

        if (jumpKeywasPressed)
        {
            rigidbodyComponent.AddForce(Vector3.up * 7, ForceMode.VelocityChange);
            jumpKeywasPressed = false;
        }
    }
}
