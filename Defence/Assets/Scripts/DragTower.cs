using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragTower : MonoBehaviour
{

   
    public Transform[] SnapLoc1;
    public int ChosenSnapPoint;
    private Vector2 InitPos;
    private Vector2 MousePos;
    private float deltax, deltay;
    public static bool Locked;
    public int test = 1;


    void Start()
    {
        InitPos = transform.position;
    }

    

    private void OnMouseDown()
    {
        
        if (!Locked)
        {
            deltax = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
            deltay = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;
        }
    }

    private void OnMouseDrag()
    {
        if (!Locked)
        {
            MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(MousePos.x - deltax, MousePos.y - deltay);
        }
    }

    private void OnMouseUp()
    {

        for (var i = 0; i < SnapLoc1.Length; i++)

        {
            
            
        }

        if (Mathf.Abs(transform.position.x - SnapLoc1[0].position.x)<= .5f && Mathf.Abs(transform.position.y - SnapLoc1[0].position.y)<= .5f)
        {
            transform.position = new Vector2(SnapLoc1[0].position.x, SnapLoc1[0].position.y);
            Locked = true;
        }
        else if (Mathf.Abs(transform.position.x - SnapLoc1[1].position.x) <= .5f && Mathf.Abs(transform.position.y - SnapLoc1[1].position.y) <= .5f)
        {
            transform.position = new Vector2(SnapLoc1[1].position.x, SnapLoc1[1].position.y);
            Locked = true;
        }
        else if(Mathf.Abs(transform.position.x - SnapLoc1[2].position.x) <= .5f && Mathf.Abs(transform.position.y - SnapLoc1[2].position.y) <= .5f)
        {
            transform.position = new Vector2(SnapLoc1[2].position.x, SnapLoc1[2].position.y);
            Locked = true;
        }
        else if(Mathf.Abs(transform.position.x - SnapLoc1[3].position.x) <= .5f && Mathf.Abs(transform.position.y - SnapLoc1[3].position.y) <= .5f)
        {
            transform.position = new Vector2(SnapLoc1[3].position.x, SnapLoc1[3].position.y);
            Locked = true;
        }
        else
        {
            transform.position = new Vector2(InitPos.x, InitPos.y);
        }

        

    }

   
    
}
