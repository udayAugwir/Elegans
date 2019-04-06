using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SoldScript1 : MonoBehaviour
{
    public GameObject soldvilla;

    public void Start()
    {
        GameObject[] sold = GameObject.FindGameObjectsWithTag("Sold");
        for (int i = 0; i < sold.Length; i++)
        {
#pragma warning disable CS0618 // Type or member is obsolete
            int soldchild = sold[i].transform.GetChildCount();
            for (int j = 0; j < soldchild; j++)
            {
                //orgmat[j] = sold[i].transform.GetChild(j).GetComponent<Renderer>().material;
            }
#pragma warning restore CS0618 // Type or member is obsolete
        }
    }


    public void Sold()
    {
        GameObject[] sold = GameObject.FindGameObjectsWithTag("EastSold");
        for(int i = 0; i<sold.Length; i++)
        {
#pragma warning disable CS0618 // Type or member is obsolete
            GameObject instvilla = Instantiate(soldvilla, sold[i].transform.position, sold[i].transform.rotation);
            instvilla.transform.parent = GameObject.FindWithTag("EastFace").transform;
            instvilla.transform.position = sold[i].transform.position;
            instvilla.transform.localScale = sold[i].transform.localScale;

            //int soldchild = sold[i].transform.GetChildCount();

            //for(int j = 0; j<soldchild; j++)
            //{
              //  sold[i].transform.GetChild(j).GetComponent<Renderer>().material.color = Color.red;
            //}
#pragma warning restore CS0618 // Type or member is obsolete
        }
    }

    public void clearsold()
    {
        //SceneManager.LoadScene("Layout02");
    }

}
