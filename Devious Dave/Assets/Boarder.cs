using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boarder : MonoBehaviour
{
    public float distanceFromEdge;
    LineRenderer lineRenderer;
    public float radius;
    public int segments = 360;
    public float anglePerSegment;
    
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        //radius = (transform.localScale.x /2) - distanceFromEdge;
        lineRenderer.positionCount = segments;
        anglePerSegment = 360 / segments;

        for (int i = 0; i < segments; i++)
        {
            float CurrentAngle = Mathf.Abs(i * anglePerSegment);
            
            float x = (Mathf.Cos(Mathf.Deg2Rad *CurrentAngle)* radius) + transform.position.x;
            float y = (Mathf.Sin(Mathf.Deg2Rad *CurrentAngle) * radius) + transform.position.y;
            //Debug.Log("x:" + x);
            //Debug.Log("y:" + y);
            Vector3 pos = new Vector3(x, y,-1);
            
            
            lineRenderer.SetPosition(i,pos);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
