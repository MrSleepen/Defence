using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private Transform target;
    public float speed = 1;
    public int AttackPower = 3;
    public GameObject ArrowPrefab;
    private bool Set = false;
   
    
    public void Seek(Transform _target)
    {
        target = _target;
    }
    void Update()
    {
     
      

       
        if(target == null)
        {
            Debug.Log("null");
            Destroy(ArrowPrefab);
           
            return;
        }
        
        Vector3 dir = target.position - transform.position;
       
  
        float distancethisFrame = .5f;

        if(dir.magnitude <= distancethisFrame)
        {
            target.GetComponent<Enemy1>().Damage(Dam:AttackPower) ;
            Destroy(ArrowPrefab);
            
            return;
        }
        transform.Translate(dir.normalized * distancethisFrame, Space.World);


        Vector3 vectorToTarget = target.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * speed);



    }
    
            

   

}
