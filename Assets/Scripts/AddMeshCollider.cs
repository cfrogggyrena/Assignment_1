using UnityEngine;

public class AddMeshCollider : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (Transform child in transform)
        {
            if (child.GetComponent<MeshRenderer>() != null)
            {
                if (child.gameObject.GetComponent<MeshCollider>() == null)
                {
                    MeshCollider mc = child.gameObject.AddComponent<MeshCollider>();

                    // mover el objeto con físicas, activa 'convex'
                    mc.convex = true;
                }
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
