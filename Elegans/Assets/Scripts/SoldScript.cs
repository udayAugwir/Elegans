using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SoldScript : MonoBehaviour
{
    public void Sold()
    {
        GameObject[] unsold = GameObject.FindGameObjectsWithTag("UnSold");
        GameObject[] sold = GameObject.FindGameObjectsWithTag("Sold");

        for(int i = 0; i<unsold.Length; i++)
        {
#pragma warning disable CS0618 // Type or member is obsolete
            int unsoldchild = unsold[i].transform.GetChildCount();
#pragma warning restore CS0618 // Type or member is obsolete

            for (int j = 0; j< unsoldchild; j++)
            {
                unsold[i].transform.GetChild(j).GetComponent<Renderer>().enabled = false;
            }
            //unsold[i].SetActive(false);
            //sold[i].SetActive(true);
        }
        for (int i = 0; i < sold.Length; i++)
        {
#pragma warning disable CS0618 // Type or member is obsolete
            int soldchild = sold[i].transform.GetChildCount();
#pragma warning restore CS0618 // Type or member is obsolete

            for (int j = 0; j < soldchild; j++)
            {
                sold[i].transform.GetChild(j).GetComponent<Renderer>().enabled = true;
            }
            //unsold[i].SetActive(false);
            //sold[i].SetActive(true);
        }
    }

    public void clearsold()
    {
        GameObject[] unsold = GameObject.FindGameObjectsWithTag("UnSold");
        GameObject[] sold = GameObject.FindGameObjectsWithTag("Sold");

        for (int i = 0; i < unsold.Length; i++)
        {
#pragma warning disable CS0618 // Type or member is obsolete
            int unsoldchild = unsold[i].transform.GetChildCount();
#pragma warning restore CS0618 // Type or member is obsolete

            for (int j = 0; j < unsoldchild; j++)
            {
                unsold[i].transform.GetChild(j).GetComponent<Renderer>().enabled = true;
            }
            //unsold[i].SetActive(false);
            //sold[i].SetActive(true);
        }
        for (int i = 0; i < sold.Length; i++)
        {
#pragma warning disable CS0618 // Type or member is obsolete
            int soldchild = sold[i].transform.GetChildCount();
#pragma warning restore CS0618 // Type or member is obsolete

            for (int j = 0; j < soldchild; j++)
            {
                sold[i].transform.GetChild(j).GetComponent<Renderer>().enabled = false;
            }
            //unsold[i].SetActive(false);
            //sold[i].SetActive(true);
        }

    }

}
