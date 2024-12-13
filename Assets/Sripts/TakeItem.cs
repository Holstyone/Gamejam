using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeItem : MonoBehaviour

{
    float distance = 3;
    public Transform pos;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    void OnMouseDown()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, distance))
        {
            rb.isKinematic = true;
            rb.MovePosition(pos.position);
        }
    }

    private void FixedUpdate()
    {
        if (rb.isKinematic == true)
        {
            this.gameObject.transform.position = pos.position;
            if (Input.GetKeyDown(KeyCode.G))
            {
                rb.useGravity = true;
                rb.isKinematic = false;
                rb.AddForce(Camera.main.transform.forward * 500);

            }
        }
        Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward, Color.blue);
    }
}