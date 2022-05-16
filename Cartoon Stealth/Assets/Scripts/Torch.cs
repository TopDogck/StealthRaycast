using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{
    public Rigidbody rb;
    public CapsuleCollider cc;
    public Transform player, lightSlot;

    public float pickupRange;
    public float dropAheadForce, dropUpForce;

    public bool equiped;
    public bool full;

    public void Start()
    {
        if (!equiped)
        {
            rb.isKinematic = false;
            //cc.isTrigger = false;
        }
        if (equiped)
        {
            rb.isKinematic = true;
            //cc.isTrigger = true;
            full = true;
        }
    }

    public void Update()
    {
        Vector3 distenceToPlayer = player.position - transform.position;
        if (!equiped && distenceToPlayer.magnitude <= pickupRange && !full && Input.GetKeyDown(KeyCode.E))
        {
            PickUp();
        }

        if (equiped && Input.GetKeyDown(KeyCode.Q))
        {
            Drop();
        }
    }

    private void PickUp()
    {
        equiped = true;
        full = true;

        rb.isKinematic = true;
        //cc.isTrigger = true;

        transform.SetParent(lightSlot);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        //transform.localScale = Vector3.zero;
    }
    private void Drop()
    {
        equiped = false;
        full = false;

        rb.isKinematic = false;
        //cc.isTrigger = false;

        transform.SetParent(null);

        rb.velocity = player.GetComponent<Rigidbody>().velocity;

        rb.AddForce(player.forward * dropAheadForce, ForceMode.Impulse);
        rb.AddForce(player.up * dropUpForce, ForceMode.Impulse);

        float randomRange = Random.Range(-1f, 1f);
        rb.AddTorque(new Vector3(randomRange, randomRange, randomRange) * 10);
    }
}
