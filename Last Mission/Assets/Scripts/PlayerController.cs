using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 5.0f;

    private NPC currentNPC;

    private void Move()
    {
        var horizontalInput = Input.GetAxis("Horizontal");
        var verticalInput = Input.GetAxis("Vertical");

        var newPosition = new Vector3(transform.position.x + horizontalInput * speed * Time.deltaTime,
            transform.position.y, transform.position.z + verticalInput * speed * Time.deltaTime);

        transform.position = newPosition;
    }

    private void HandleInteraction()
    {
        if (Input.GetKeyDown(KeyCode.E) && currentNPC != null)
        {
            currentNPC.InteractWithPlayer();
        }
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        HandleInteraction();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponentInParent<NPC>() != null)
        {
            currentNPC = other.gameObject.GetComponentInParent<NPC>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponentInParent<NPC>() != null)
        {
            currentNPC.DisableInteraction();
            currentNPC = null;
        }
    }
}
