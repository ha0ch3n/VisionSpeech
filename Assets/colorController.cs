using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorController : MonoBehaviour
{
    
    [SerializeField] private Transform cube;
    [SerializeField] private Transform cylinder;
    private Renderer indicatorRenderer;
    private float offset = (float)0.2; 
    
    public void Start()
    {
        indicatorRenderer = gameObject.GetComponent<Renderer>();
    }
    
    public void Update()
    {
        // Debug.Log(cylinder.position);
        if (cylinder.position.x > 0 - offset && cylinder.position.x < 0 + offset
            && cylinder.position.y > 1 - offset && cylinder.position.y < 1 + offset)
        {
            indicatorRenderer.material.color = Color.green;
        }
        else
        {
            indicatorRenderer.material.color = Color.red;
        }
    }
}
