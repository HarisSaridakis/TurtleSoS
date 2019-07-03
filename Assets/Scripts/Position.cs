using UnityEngine;
using System.Collections;

internal class Position : MonoBehaviour
{

    private GameObject Trash;
    private int ID;

    public Position(GameObject Trash,int ID)
    {
        this.Trash = Trash;
        this.ID = ID;

    }

    
}
