using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropUI : MonoBehaviour
{
    public GameObject Tower;
    public GameObject UIOBJ;
    public GameObject DisappearPanel;
    public GameObject ReappearPanel;
    public GameObject Snappoint;
    public RectTransform TowerPanel;
    private bool dragging;
    public bool playableArea = false;
   
    Vector3 mousePos;


    public void Awake()
    {
        
    }

    public void Update()
    {
      
        mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f);
        if (dragging)
        {
            UIOBJ.transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
        else
        {
            UIOBJ.transform.position = Snappoint.transform.position;
        }
    }

    public void MouseD()
    {
        
        dragging = true;
        TowerPanel.transform.position = DisappearPanel.transform.position;

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
          
            
                Instantiate(Tower, wordPos, Quaternion.identity);
         
            

            TowerPanel.transform.position = ReappearPanel.transform.position;
           
        }
    }

    
}
