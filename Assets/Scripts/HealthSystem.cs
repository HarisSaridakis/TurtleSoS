
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour {

  
    private List<GameObject> Health = new List<GameObject>();
    private GameObject DestroyHeart;
    public GameObject Heart;
    public static bool IsDead=false;
    public static bool PlusOne = false;
    void Start()
    {

        SetHeart(3);

    }

    public  void SetHeart(int HeartNumber) // puts three hearts on screen
    {
        Debug.Log("HeartNumber " + Heart);
        float k = 0F;
        for (int i = 0; i <HeartNumber; i++)
        {
           
            GameObject Current = Instantiate(Heart, new Vector3(gameObject.transform.position.x + k, gameObject.transform.position.y, -4), Quaternion.identity)as GameObject;
          
            Health.Add(Current);
            k += 0.7F;
        }


    }

   public  void RemoveHeart() 
    {
        if (Health.Count != 0) // if list is not empty removes the last heart
        {
            GameObject fre = Health[Health.Count - 1];
            
            Destroy(fre);
            Health.Remove(Health[Health.Count - 1]);
        }

    }

    public void AddHeart()
    {

        GameObject Current = Instantiate(Heart, new Vector3(Health[Health.Count - 1].transform.position.x +0.7F, gameObject.transform.position.y, -4), Quaternion.identity) as GameObject;
        // Instantiate(gameObject, new Vector3(gameObject.transform.position.x + k, gameObject.transform.position.y, -4), Quaternion.identity);
        Health.Add(Current);

    }

    void Update()
    {

        if (IsDead) // IsDead sets true to move script
        {

            RemoveHeart();
            IsDead = false;

        }

        if (PlusOne)
        {

            AddHeart();
            PlusOne = false;

        }




    }
	
}
