using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    private bool Dieing = false;
    public int Health;
    public GameObject This;
    public int CreatureMultiplier = 1;
    public int Attack = 1;
    public Animator Enemy1anim;
    private bool AttackAnimating;
    public int CreatureWorth;
    public int IndependentVariable;
    
    

    // Start is called before the first frame update

    void Start()
    {
        Health = PlayerPrefs.GetInt("RoundNum") * 4;
        Attack = PlayerPrefs.GetInt("RoundNum") / 4;
    }
    // Update is called once per frame
    void Update()
      
    {
        
        CreatureWorth = 10 + PlayerPrefs.GetInt("RoundNum") * IndependentVariable;

            if (Health <= 0)
            {   
                Dieing = true;
            }
            //If Dieing Start Death() Coroutine  
            if (Dieing == true)
            {     
                Dieing = false;    
                StartCoroutine(Death());          
            }
    }
    //Damage Called from tower script upon Hit
    public void Damage(int Dam)
    {   
        Health -= Dam;
    }
    //Run When Health =0a
    IEnumerator Death()
    {
        Enemy1anim.SetBool("Alive", false);
        yield return new WaitForSeconds(.5f);
        PlayerPrefs.SetInt("KilledCreatures", PlayerPrefs.GetInt("KilledCreatures") + 1);
        PlayerPrefs.SetInt("CurMoneyt1", PlayerPrefs.GetInt("CurMoneyt1") + CreatureWorth); 
        Destroy(This);
    }
    void OnTriggerStay(Collider other)
    {

        if (other.gameObject.tag == "Base" && AttackAnimating == false)
        {
            Enemy1anim.SetBool("IsAttacking", true);
            StartCoroutine(AttackEnum());
            //Destroy(This);
        }
    }

    IEnumerator AttackEnum()
    { 
        yield return new WaitForSeconds(.5f);
        PlayerPrefs.SetInt("BaseHealth", PlayerPrefs.GetInt("BaseHealth") - Attack);
        AttackAnimating = false;
    }
  
}
