using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CH : MonoBehaviour
{
    public Canvas CHcanv;
    public Image CHInfo;
    public GameObject First, Second, Third, Infoicon;
    bool info, bool1, bool2, bool3;


    private void OnMouseDown()
    {
        gameObject.SetActive(false);
        CHcanv.gameObject.SetActive(true);

    }

    public void chi()
    {
        if (!info)
        {
            CHInfo.gameObject.SetActive(true);
            First.SetActive(true);
            Second.SetActive(true);
            Third.SetActive(true);
            info = true;

        }
        else
        {
            CHInfo.gameObject.SetActive(false);
            info = false;
        }

    }

    public void ch1()
    {
        CHInfo.gameObject.SetActive(false);
        if (!bool1)
        {
            First.SetActive(false);
            Second.SetActive(false);
            Third.SetActive(false);
            bool1 = true;
            bool2 = false;
            bool3 = false;
        }
        else
        {
            First.SetActive(true);
            Second.SetActive(true);
            Third.SetActive(true);
            bool1 = false;

        }


    }

    public void ch2()
    {
        CHInfo.gameObject.SetActive(false);
        First.SetActive(true);
        Third.SetActive(false);

        if (!bool2)
        {
            Second.SetActive(false);
            Third.SetActive(false);
            bool2 = true;
            bool3 = false;
            bool1 = false;
        }
        else
        {
            Second.SetActive(true);
            Third.SetActive(true);
            bool2 = false;
        }

    }

    public void ch3()
    {
        CHInfo.gameObject.SetActive(false);
        First.SetActive(true);
        Second.SetActive(true);
        if (!bool3)
        {
            Third.SetActive(false);
            bool3 = true;
            bool2 = false;
            bool1 = false;
        }
        else
        {
            bool3 = false;
            Third.SetActive(true);
        }

    }
    public void chexit()
    {
        Infoicon.SetActive(true);
        CHcanv.gameObject.SetActive(false);

    }
    public void walkthrough()
    {
        SceneManager.LoadScene("ClubHouse");
    }
}
