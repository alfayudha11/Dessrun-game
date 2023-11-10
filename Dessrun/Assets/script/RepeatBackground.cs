using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    public GameObject camera;
    public float parallaxEffect;
    private float width, positionX;

    // Start is called before the first frame update
    void Start()
    {
        width = GetComponent<SpriteRenderer>().bounds.size.x;
        positionX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        float parallexDistace=camera.transform.position.x*parallaxEffect;
        float remainingDistaace = camera.transform.position.x * (1 - parallaxEffect);
        
        transform.position = new Vector3(positionX + parallexDistace, transform.position.y, transform.position.z);

        if (remainingDistaace > positionX + width)
        {
            positionX += width;
        }

    }
}
