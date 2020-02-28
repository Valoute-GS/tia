using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollidersManager : MonoBehaviour
{

    List<GameObject> currentCollisions = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {

    }

    private void OnTriggerEnter(Collider col)
    {
        currentCollisions.Add(col.gameObject);
        Debug.Log("ENTER : " + col.gameObject.name);

        Destroy(col.gameObject);
        foreach (GameObject gObject in currentCollisions)
        {
        }
    }

    private void OnTriggerExit(Collider col)
    {
        currentCollisions.Remove(col.gameObject);
        Debug.Log("EXIT : " + col.gameObject.name);

        foreach (GameObject gObject in currentCollisions)
        {
            
        }
    }
}
