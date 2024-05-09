using System;
using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;

public class activeController : MonoBehaviour
{
    [SerializeField] private Transform cube;
    [SerializeField] private Transform cylinder;
    [SerializeField] private List<GameObject> resetList;
    private Color targetColor;
    private float offset = (float)0.25; 
    [SerializeField] private GameObject subtract;
    
    public void ToggleActive()
    {
        ResetList();
        gameObject.SetActive(!gameObject.activeSelf);
        SetMaterial();
    }
    
    private void ResetList()
    {
        for (int i = 0; i < resetList.Count; i++)
        {
            resetList[i].gameObject.SetActive(false);
        }
    }

    private void SetMaterial()
    {
        if (cube.position.z > cylinder.position.z)
        {
            targetColor = cube.GetComponent<Renderer>().material.color;
        }
        else
        {
            targetColor = cylinder.GetComponent<Renderer>().material.color;
        }
        gameObject.transform.GetChild(0).GetComponent<Renderer>().material.color = targetColor;
        if (gameObject.GetComponent<Renderer>())
        {
            gameObject.GetComponent<Renderer>().material.color = targetColor;
        }
    }

    public void subtractHandler()
    {
        Debug.Log("substract");
        ResetList();
        
        if (cube.position.z > cylinder.position.z)
        {
            gameObject.SetActive(!gameObject.activeSelf);
            subtract.SetActive(false);
        }
        else
        {
            subtract.SetActive(!subtract.activeSelf);
            gameObject.SetActive(false);
        }
    }

    public void Reset()
    {
        ResetList();
        cube.gameObject.SetActive(true);
        cylinder.gameObject.SetActive(true);
        cylinder.localPosition = new Vector3(cube.position.x + offset, cylinder.position.y, cylinder.position.z);
        cylinder.localPosition = new Vector3(cylinder.position.x, cube.position.y - offset, cylinder.position.z);
    }
}
