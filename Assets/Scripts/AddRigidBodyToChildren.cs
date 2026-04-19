using UnityEngine;

public class AddRigidBodyToChildren : MonoBehaviour
{
    void Start()
    {
        // iterate through every direct child of this transform
        foreach (Transform child in transform)
        {
            // add BoxCollider if it doesn't already exist
            if (child.gameObject.GetComponent<BoxCollider>() == null)
            {
                child.gameObject.AddComponent<BoxCollider>();
            }

            // add Rigidbody if it doesn't already exist
            if (child.gameObject.GetComponent<Rigidbody>() == null)
            {
                child.gameObject.AddComponent<Rigidbody>();
            }
        }
    }
}
