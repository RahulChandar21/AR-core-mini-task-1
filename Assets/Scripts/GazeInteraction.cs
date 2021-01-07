using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeInteraction : MonoBehaviour
{
    public GameObject cube1Info;
    public GameObject cube2Info;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Physics.Raycast(transform.position, transform.forward, out RaycastHit hit))
        {
            GameObject hitObject = hit.collider.gameObject;

            if(hitObject.CompareTag("Cube1"))
            {
                //cube1.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.green);
                //cube2.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.white);

                cube1Info.SetActive(true);
                cube2Info.SetActive(false);
            }
            if (hitObject.CompareTag("Cube2"))
            {
                //cube1.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.white);
                //cube2.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.green);

                cube1Info.SetActive(false);
                cube2Info.SetActive(true);
            }
        }
    }
}
