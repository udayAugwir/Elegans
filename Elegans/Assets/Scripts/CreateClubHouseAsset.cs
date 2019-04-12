using UnityEngine;
using System.Collections;
using UnityEditor;

public class CreateClubHouseAsset : Editor
{
    [MenuItem("Assets/Create Clubhouse Asset")]
    static void ExportBundle()
    {
        string bundlePath = "Assets/AssetBundle/clubhouse.unity3d";
        Object[] selectedAssets = Selection.GetFiltered(typeof(Object), SelectionMode.Assets);
        BuildPipeline.BuildAssetBundle(Selection.activeObject, selectedAssets, bundlePath, BuildAssetBundleOptions.CollectDependencies | BuildAssetBundleOptions.CompleteAssets, BuildTarget.StandaloneWindows);

    }

}
