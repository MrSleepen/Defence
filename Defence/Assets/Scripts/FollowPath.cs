using System.Collections;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    [SerializeField]
    private Transform[] routes;

    private int routeToGo;
    private float tParam;
    private Vector2 EnemyPos;
    private float speedModifier;
    private bool coroutineAllowed;
    private SpriteRenderer mySpriteRenderer;
    public bool Original = true;


void Awake()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        routeToGo = 0;
        tParam = 0f;
        speedModifier = .2f;
        coroutineAllowed = true;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (!Original)
        {
            if (coroutineAllowed)
            {
                StartCoroutine(GoByTheRoute(routeToGo));
            }


        }
    }

    private IEnumerator GoByTheRoute(int routeNumber)
    {
        coroutineAllowed = false;
        Vector2 theScale = transform.localScale;
        Vector2 p0 = routes[routeNumber].GetChild(0).position;
        Vector2 p1 = routes[routeNumber].GetChild(1).position;
        Vector2 p2 = routes[routeNumber].GetChild(2).position;
        Vector2 p3 = routes[routeNumber].GetChild(3).position;
        if(p0.x > p3.x)
        {
            mySpriteRenderer.flipX = true;
        }
        else
        {
            //Movig Right
            
        }

        while(tParam < 1)
        {
            tParam += Time.deltaTime * speedModifier;

            EnemyPos = Mathf.Pow(1 - tParam, 3) * p0 + 3 * Mathf.Pow(1 - tParam, 2) * tParam * p1 + 3 * (1 - tParam) * Mathf.Pow(tParam, 2) * p2 + Mathf.Pow(tParam, 3) * p3;

            transform.position = EnemyPos;
            yield return new WaitForEndOfFrame();
        }
        tParam = 0f;

        routeToGo += 1;

        if (routeToGo > routes.Length - 1)
            routeToGo = 0;

        coroutineAllowed = true;
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Base")
        {
            speedModifier = 0;
        }
    }
    public void NotOriginal()
    {
        Original = false;
    }
}
