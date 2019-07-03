using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour {

    private Vector3 offset;
    public int pos=0;
 
    private Collider Col;
    private bool Chk;
    private List<GameObject> allos = new List<GameObject>();
    private List<GameObject> BackUpAllos = new List<GameObject>();
  
  


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Turtle")
        {
            Debug.Log("Entered");
            other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            other.gameObject.GetComponent<Move>().anim.SetBool("Obstacle", true);
            other.gameObject.GetComponent<Move>().timerCheck = true;
            Chk = true;
            Debug.Log("Other: "+ other.gameObject);
           
            allos.Add(other.gameObject);
            Debug.Log("allos: " + allos.Count);

        }

      
           
        
    }

    public void SetPos(int position) {

        pos = position;

    }

    void OnMouseUp() {
      //  Debug.Log("Up");
        Col = GetComponent<Collider>(); ;
         Col.enabled = true;
        Chk = false;
    }


    void OnMouseDown()
    {
       // Debug.Log("Down");
        offset = gameObject.transform.position -
            Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
    }

    void OnMouseDrag()

    {
        //Debug.Log("Drag");
        Col = GetComponent<Collider>(); ;
       Col.enabled = false;
        if (Chk == true)
        {


            FauxExit();
            Chk = false;
        }
        Vector3 newPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f);
        transform.position = Camera.main.ScreenToWorldPoint(newPosition) + offset;
        
    }

    void FauxExit()
    {
      
        try
        {
            foreach (GameObject allo in allos)
            {
                Debug.Log("Looping");
                if (allo != null)
                {
                    allo.GetComponent<Move>().timerCheck = false;
                    allo.GetComponent<Move>().GetComponent<Move>().timer = 0;
                    allo.GetComponent<Move>().anim.SetBool("Obstacle", false);
                    allo.GetComponent<Rigidbody>().velocity = allo.transform.up * 0.75F;
                }

               
                
            }
            
            allos.Clear();
            Debug.Log("Cleared" + allos.Count);
        }
        catch (MissingReferenceException e )
        {

            Debug.Log("Oops" + e );
            allos.Clear();
        }
        catch (System.NullReferenceException ex)
        {
            Debug.Log("Oops" + ex);

        }
    }
}
