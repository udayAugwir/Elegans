using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ClubHouseDownloader : MonoBehaviour
{
    public string url;
    GameObject clubhouseGO;
    public Text loadingText;
    public Transform spawnPos;
    private string prefabName = "ClubHouse";

    public void Start()
    {
        Load(prefabName);
    }

    IEnumerator LoadBundle(string clubhouseName)
    {
        while (!Caching.ready)
        {
            yield return null;
        }

        //Begin download
        WWW www = WWW.LoadFromCacheOrDownload(url, 0);
        yield return www;

        //Load the downloaded bundle
        AssetBundle bundle = www.assetBundle;

        //Load an asset from the loaded bundle
        AssetBundleRequest bundleRequest = bundle.LoadAssetAsync(clubhouseName, typeof(GameObject));
        yield return bundleRequest;

        //get object
        GameObject obj = bundleRequest.asset as GameObject;

        clubhouseGO = Instantiate(obj, spawnPos.position, Quaternion.identity) as GameObject;
        loadingText.text = "";

        bundle.Unload(false);
        www.Dispose();
    }

    public void Load(string clubhouseName)
    {
        if (clubhouseGO)
        {
            Destroy(clubhouseGO);
        }

        loadingText.text = "Loading...";
        StartCoroutine(LoadBundle(clubhouseName));
    }
}