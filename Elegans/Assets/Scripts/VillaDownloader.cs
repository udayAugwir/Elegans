using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VillaDownloader : MonoBehaviour
{
    public string url;
    GameObject villaGO;
    public Text loadingText;
    public Transform spawnPos;
    private string prefabName = "EastVilla";

    public void Start()
    {
        Load(prefabName);
    }

    IEnumerator LoadBundle(string villaName)
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
        AssetBundleRequest bundleRequest = bundle.LoadAssetAsync(villaName, typeof(GameObject));
        yield return bundleRequest;

        //get object
        GameObject obj = bundleRequest.asset as GameObject;

        villaGO = Instantiate(obj, spawnPos.position, Quaternion.identity) as GameObject;
        loadingText.text = "";

        bundle.Unload(false);
        www.Dispose();
    }

    public void Load(string villaName)
    {
        if (villaGO)
        {
            Destroy(villaGO);
        }

        loadingText.text = "Loading...";
        StartCoroutine(LoadBundle(villaName));
    }
}