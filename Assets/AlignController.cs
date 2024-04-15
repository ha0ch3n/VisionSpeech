using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlignController : MonoBehaviour
{ 
    private Transform thisShape;
    [SerializeField] private Transform otherShape;
    [SerializeField] private List<GameObject> resetList;
    private float offset = (float)0.25; 
    
    void Start()
    {
        thisShape = GetComponent<Transform>();
    }
    
    public void leftAlign()
    {
        ResetList();
        thisShape.localPosition = new Vector3(otherShape.position.x + offset, thisShape.position.y, thisShape.position.z);
    }

    public void rightAlign()
    {
        ResetList();
        thisShape.localPosition = new Vector3(otherShape.position.x - offset, thisShape.position.y, thisShape.position.z);
    }
    
    public void topAlign()
    {
        ResetList();
        thisShape.localPosition = new Vector3(thisShape.position.x, otherShape.position.y + offset, thisShape.position.z);
    }

    
    public void bottomAlign()
    {
        ResetList();
        thisShape.localPosition = new Vector3(thisShape.position.x, otherShape.position.y - offset, thisShape.position.z);
    }
    
    private void ResetList()
    {
        for (int i = 0; i < resetList.Count; i++)
        {
            resetList[i].gameObject.SetActive(false);
        }
        
        thisShape.gameObject.SetActive(true);
        otherShape.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
