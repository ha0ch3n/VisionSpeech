using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activeController : MonoBehaviour
{
    [SerializeField] private Transform cube;
    [SerializeField] private Transform cylinder;
    [SerializeField] private List<GameObject> resetList;
    private Color targetColor;
    
    public void ToggleActive()
    {
        ResetList();
        gameObject.SetActive(!gameObject.activeSelf);
        // SetMaterial();
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
        Debug.Log(cube.position.z);
        Debug.Log(cylinder.position.z);
        if (cube.position.z > cylinder.position.z)
        {
            targetColor = cube.GetComponent<Renderer>().material.color;
        }
        else
        {
            targetColor = cylinder.GetComponent<Renderer>().material.color;
        }
        Debug.Log(targetColor);
        Debug.Log(gameObject.transform.GetChild(0));
        gameObject.transform.GetChild(0).GetComponent<Renderer>().material.color = targetColor;
    }

    public void Reset()
    {
        ResetList();
        cube.gameObject.SetActive(true);
        cylinder.gameObject.SetActive(true);
    }
}
