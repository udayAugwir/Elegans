using UnityEngine;
using System.Collections;
using UnityEditor;

public class CreateVillaAsset : Editor
{
    [MenuItem("Assets/Create Villa Asset")]
    static void ExportBundle()
    {
        string bundlePath = "Assets/AssetBundle/villa.unity3d";
        Object[] selectedAssets = Selection.GetFiltered(typeof(Object), SelectionMode.Assets);
        BuildPipeline.BuildAssetBundle(Selection.activeObject, selectedAssets, bundlePath, BuildAssetBundleOptions.CollectDependencies | BuildAssetBundleOptions.CompleteAssets, BuildTarget.StandaloneWindows);

    }

}
