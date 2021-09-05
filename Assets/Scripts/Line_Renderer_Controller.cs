using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line_Renderer_Controller : MonoBehaviour
{
    public float MaxLeggLength;
    public LineRenderer Line;
    private Vector3 fottPosition;
    private void Start()
    {
        SetFott();  
    }
    private void Update()
    {
        if (OutOfFott())
        {
            SetFott();
        }
        DrawLegg();
    }

    private bool OutOfFott()
    {
        return Vector3.Distance(transform.position, fottPosition) > MaxLeggLength;
    }

    private void SetFott()
    {
        Vector3 direction = transform.right;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, MaxLeggLength);

        if (hit == false)
        {
            
            return;
        }
        
        fottPosition = hit.point;
        
    }
    
    private void DrawLegg()
    {
        Line.gameObject.SetActive(!OutOfFott());
        Line.SetPosition(1, transform.InverseTransformPoint(fottPosition));
    }
    
}
