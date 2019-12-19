using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropUI : MonoBehaviour
{
    public GameObject Tower;
    public GameObject UIOBJ;
    public RectTransform TowerPanel;
    private bool dragging;
    public bool playableArea = false;
    private Vector3 Startpos;
    Vector3 mousePos;


    public void Awake()
    {
        Startpos = transform.position;
    }

    public void Update()
    {
        mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f);
        if (dragging)
        {
            UIOBJ.transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
    }

    public void MouseD()
    {
        dragging = true;
        TowerPanel.transform.localScale= new Vector3(0, 0, 0);
        //GetComponent<CanvasGroup>().blocksRaycasts = false;

    }

    public  void MouseUP()
    {
        dragging = false;

        TowerPanel.transform.localScale = new Vector3(1, 1, 1);

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
            //or for tandom rotarion use Quaternion.LookRotation(Random.insideUnitSphere)
        }
    }

    
}
