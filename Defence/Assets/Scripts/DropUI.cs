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
    public GameObject[] Snappoint;
    public RectTransform TowerPanel;
    private bool dragging;
    public bool playableArea = false;
    private int Selectedtower;
    private int Cost;
    
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
                UIOBJ[Selectedtower].transform.position = Snappoint[Selectedtower].transform.position;
            }
        
    }

    public void MouseD()
    {
        PointerEventData pointer = new PointerEventData(EventSystem.current);
        pointer.position = Input.mousePosition;

        List<RaycastResult> raycastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointer, raycastResults);

        if (raycastResults.Count > 0)
        {
            foreach (var go in raycastResults)
            {

                Debug.Log(go.gameObject.name, go.gameObject);
                if (go.gameObject.name == "ArcherTower")
                {
                    Selectedtower = 0;
                    Cost = 100;
                    
                }
                if (go.gameObject.name == "RockTower")
                {
                   Selectedtower = 1;
                    Cost = 150;
                }
                if (go.gameObject.name == "FireTower")
                {
                    Selectedtower = 2;
                    Cost = 200;
                }
                if (go.gameObject.name == "IceTower")
                {
                    Selectedtower = 3;
                    Cost = 250;
                }
                if (go.gameObject.name == "LightTower")
                {
                    Selectedtower = 4;
                    Cost = 400;
                }
                if (go.gameObject.name == "DarkTower")
                {
                    Selectedtower = 5;
                    Cost = 500;
                }
            }
        }

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
          
            if(Cost <= PlayerPrefs.GetInt("CurMoneyt1"))
            {
                Instantiate(Tower[Selectedtower], wordPos, Quaternion.identity);
                TowerPanel.transform.position = ReappearPanel.transform.position;
                PlayerPrefs.SetInt("CurMoneyt1", PlayerPrefs.GetInt("CurMoneyt1") - Cost);
            }
            else
            {
                TowerPanel.transform.position = ReappearPanel.transform.position;
            }
                 
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
