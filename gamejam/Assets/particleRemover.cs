using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleRemover : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Remove());
    }

    IEnumerator Remove()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
