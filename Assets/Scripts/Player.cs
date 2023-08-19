using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public LineRenderer lineRenderer;

    public Color green;
    public Color red;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
        SetColorGreen();
    }

    public void StartLine(Vector2 position)
    {
        lineRenderer.SetPosition(0, position);
    }

    public void Updateline()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 currentPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            currentPosition.z = 0f;

            lineRenderer.SetPosition(1, currentPosition);
        }
    }

    private void OnMouseDown()
    {
        StartLine(transform.position);
    }

    private void OnMouseDrag()
    {
        Updateline();
    }

    private void OnMouseUp()
    {
        lineRenderer.SetPosition(0, Vector3.zero);
        lineRenderer.SetPosition(1, Vector3.zero);

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);
        if (hit.collider != null)
        {
            if (hit.collider.gameObject.tag == "Enemy_Square")
            {   
                if (lineRenderer.startColor == green)
                {
                    hit.collider.gameObject.GetComponent<Enemy>().Destroy();
                } 
                else
                {
                    hit.collider.gameObject.GetComponent<Enemy>().Wrong();
                }
                
            } 
            else if (hit.collider.gameObject.tag == "Enemy_Triangle")
            {
                if (lineRenderer.startColor == red)
                {
                    hit.collider.gameObject.GetComponent<Enemy>().Destroy();
                } 
                else
                {
                    hit.collider.gameObject.GetComponent<Enemy>().Wrong();
                }
            }
        }
    }

    public void SetColorGreen()
    {
        lineRenderer.startColor = green;
        lineRenderer.endColor = green;
    }

    public void SetColorRed()
    {
        lineRenderer.startColor = red;
        lineRenderer.endColor = red;
    }
}