using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CH1 : MonoBehaviour
{
    public Canvas CHcanv;
    public Image CHInfo;
    public GameObject Infoicon;
    bool info;


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

            info = true;

        }
        else
        {
            CHInfo.gameObject.SetActive(false);
            info = false;
        }

    }


    public void chexit()
    {
        Infoicon.SetActive(true);
        CHcanv.gameObject.SetActive(false);

    }
    public void walkthrough()
    {
        SceneManager.LoadScene("EastVilla");
    }

}
