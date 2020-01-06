using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DropUI : MonoBehaviour
{
    public GameObject[] Tower;
    
    public GameObject[] UIOBJ;
    public GameObject DisappearPanel;
    public GameObject ReappearPanel;
    public GameObject Snappoint;
    public RectTransform TowerPanel;
    private bool dragging;
    public bool playableArea = false;
    private int Selectedtower;
    
    Vector3 mousePos;


    public void Awake()
    {
        
    }

    public void Update()
    {
//Mouse over GO////////////
        RaycastHit hit;
        mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f);

        Ray ray = Camera.main.ScreenPointToRay(mousePos);
        if(Physics.Raycast(ray, out hit, 100.0f))
        {
            if(hit.transform != null)
            {
                PrintName(hit.transform.gameObject);
            }
        }
///////////////////////////
///

        

            if (dragging)
            {
                UIOBJ[Selectedtower].transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            }
            else
            {
                UIOBJ[Selectedtower].transform.position = Snappoint.transform.position;
            }
        
    }

    public void MouseD()
    {      if(ismouseoverui())
        {
            Debug.Log("Works");
            dragging = true;
            TowerPanel.transform.position = DisappearPanel.transform.position; 
        }
           
    }

    public  void MouseUP()
    {
        dragging = false;

        

        if (!RectTransformUtility.RectangleContainsScreenPoint(TowerPanel, Input.mousePosition))
        {
            Vector3 wordPos;
            Ray ray = Camera.main.ScreenPointToRay(mousePos);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 1000f))
            {
                wordPos = hit.point;
                wordPos.z = 0;
            }
            
            else
            {
                wordPos = Camera.main.ScreenToWorldPoint(mousePos);
                wordPos.z = 0;
            }
          
            
                Instantiate(Tower[Selectedtower], wordPos, Quaternion.identity);
         
            

            TowerPanel.transform.position = ReappearPanel.transform.position;
           
        }
    }
    public void PrintName(GameObject go)
    {
        print(go.name);
    }
    
    private bool ismouseoverui()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }

}
