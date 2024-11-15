using UnityEngine;
using System.Collections.Generic;

public class BackgroundGenerator : MonoBehaviour
{      
    Vector3 startPosition = new Vector3(0, 0, 0);
    float repatWidth;
    void Start()
    {
        startPosition = transform.position;
        repatWidth = GetComponent<BoxCollider2D>().size.x / 2;
    }

    void Update()
    {
        if (transform.position.x < startPosition.x - repatWidth + 10)
        {
            transform.position = startPosition;
        }
    }
}
