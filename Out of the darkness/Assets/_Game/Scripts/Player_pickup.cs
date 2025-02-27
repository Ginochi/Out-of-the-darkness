using UnityEngine;

public class PlayerPickUp2D : MonoBehaviour
{
    private GameObject pickedUpObject;

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("OnTriggerEnter2D called");
        if (other.gameObject.CompareTag("PickUp"))
        {
            Debug.Log("PickUp object detected");
            PickUp(other.gameObject);
        }
    }

    void PickUp(GameObject item)
    {
        Debug.Log("Picking up object");
        pickedUpObject = item;
        pickedUpObject.transform.SetParent(transform);
        pickedUpObject.transform.localPosition = new Vector3(0, 1, 0); // Adjust position as needed
        pickedUpObject.GetComponent<Collider2D>().enabled = false;
        pickedUpObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, GetComponent<Collider2D>().bounds.size);
    }
}