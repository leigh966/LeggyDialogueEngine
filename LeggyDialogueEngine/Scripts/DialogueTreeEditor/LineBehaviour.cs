using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineBehaviour : MonoBehaviour
{
    public Transform parent, child, canvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(parent == null || child == null) return;
        Vector3 startPos = parent.position + Vector3.down * canvas.localScale.x * 100;
        Vector3 endPos = child.position + Vector3.up * canvas.localScale.x * 100;
        Vector3 diff = endPos-startPos;
        transform.position = startPos + diff/2;
        float angle = Vector2.Angle(new Vector2(0,1), new Vector2(diff.x, diff.y));
        if(diff.x < 0) transform.eulerAngles = new Vector3(0, 0, angle+90);
        else transform.eulerAngles = new Vector3(0, 0, -(angle+90));
        transform.localScale = new Vector3(diff.magnitude / canvas.transform.localScale.x / 500,1,1);
    }
}
