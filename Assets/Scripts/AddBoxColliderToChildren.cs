using UnityEngine;

public class AddBoxColliderToChildren : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //void Start()
    //{
    //    // iterate through every direct child of this transform
    //    foreach (Transform child in transform)
    //    {
    //        // add BoxCollider if it doesn't already exist
    //        if (child.gameObject.GetComponent<BoxCollider>() == null)
    //        {
    //            child.gameObject.AddComponent<BoxCollider>();

    //        }
    //    }

    //}
    void Start()
    {
        foreach (Transform child in transform)
        {
            // Intentamos obtener el Renderer para saber el tamaño del modelo
            MeshRenderer meshRenderer = child.GetComponent<MeshRenderer>();

            if (meshRenderer != null)
            {
                BoxCollider bc = child.gameObject.GetComponent<BoxCollider>();
                if (bc == null)
                {
                    bc = child.gameObject.AddComponent<BoxCollider>();
                }

                // El truco: Usar los bounds del renderer
                // Los bounds están en espacio global, así que los convertimos a local
                Bounds bounds = meshRenderer.localBounds;
                bc.center = bounds.center;
                bc.size = bounds.size;
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
