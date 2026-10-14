using UnityEngine;
using System.Collections;
public class PanelController : MonoBehaviour
{

    IEnumerator LoadPanelSlide()
    {
        while (true)
        {
            yield return new WaitForSeconds(5);

            GetComponent<Animator>().SetTrigger("Slide");
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine("LoadPanelSlide");
    }

    // Update is called once per frame
    void Update()
    {

    }
}


