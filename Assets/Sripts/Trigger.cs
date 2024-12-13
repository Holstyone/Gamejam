using UnityEngine;

public class Trigger : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] Collider ObjectCollider;

    void Start()
    {
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody>();
            rb.isKinematic = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("aj");
        if (other.CompareTag("Player"))
        {
            ActivateScript();
        }
    }
    void OnTriggerExit(Collider other)
    {
        Debug.Log("Wyszedł");
        ObjectCollider.isTrigger = false;
    }

    private void ActivateScript()
    {
        Debug.Log("Aktywacja");
        rb.isKinematic = false;
        rb.useGravity = true;
    }
}
