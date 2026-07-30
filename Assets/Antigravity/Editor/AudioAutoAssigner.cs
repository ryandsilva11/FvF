using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

[InitializeOnLoad]
public class AudioAutoAssigner
{
    static AudioAutoAssigner()
    {
        EditorApplication.delayCall += AssignAudioFiles;
    }

    [MenuItem("Antigravity/Vincular Sons dos Itens e Vida")]
    public static void AssignAudioFiles()
    {
        AudioClip lifeSFX = AssetDatabase.LoadAssetAtPath<AudioClip>("Assets/Antigravity/sound/lifeSFX.mp3");
        AudioClip itemSFX = AssetDatabase.LoadAssetAtPath<AudioClip>("Assets/Antigravity/sound/itemSFX.mp3");

        if (lifeSFX == null || itemSFX == null)
        {
            Debug.LogWarning("[Antigravity] Arquivos de audio lifeSFX.mp3 ou itemSFX.mp3 nao foram encontrados!");
            return;
        }

        // Prefab de Life
        GameObject lifePrefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/prefabs/Life.prefab");
        if (lifePrefab != null)
        {
            Life lifeScript = lifePrefab.GetComponent<Life>();
            if (lifeScript != null)
            {
                AudioSource src = lifePrefab.GetComponent<AudioSource>();
                if (src == null) src = lifePrefab.AddComponent<AudioSource>();
                src.playOnAwake = false;

                SerializedObject so = new SerializedObject(lifeScript);
                so.FindProperty("collect").objectReferenceValue = lifeSFX;
                so.FindProperty("oAudioSource").objectReferenceValue = src;
                so.ApplyModifiedProperties();

                EditorUtility.SetDirty(lifePrefab);
            }
        }

        // Prefab de Item
        GameObject itemPrefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/prefabs/Item.prefab");
        if (itemPrefab != null)
        {
            ItemChao itemScript = itemPrefab.GetComponent<ItemChao>();
            if (itemScript != null)
            {
                AudioSource src = itemPrefab.GetComponent<AudioSource>();
                if (src == null) src = itemPrefab.AddComponent<AudioSource>();
                src.playOnAwake = false;

                SerializedObject so = new SerializedObject(itemScript);
                so.FindProperty("collect").objectReferenceValue = itemSFX;
                so.FindProperty("oAudioSource").objectReferenceValue = src;
                so.ApplyModifiedProperties();

                EditorUtility.SetDirty(itemPrefab);
            }
        }

        // Objetos ja presentes na Cena aberta
        Life[] sceneLifes = Object.FindObjectsByType<Life>(FindObjectsInactive.Include, FindObjectsSortMode.None);
        foreach (Life l in sceneLifes)
        {
            AudioSource src = l.GetComponent<AudioSource>();
            if (src == null) src = l.gameObject.AddComponent<AudioSource>();
            src.playOnAwake = false;

            l.collect = lifeSFX;
            l.oAudioSource = src;
            EditorUtility.SetDirty(l);
        }

        ItemChao[] sceneItems = Object.FindObjectsByType<ItemChao>(FindObjectsInactive.Include, FindObjectsSortMode.None);
        foreach (ItemChao it in sceneItems)
        {
            AudioSource src = it.GetComponent<AudioSource>();
            if (src == null) src = it.gameObject.AddComponent<AudioSource>();
            src.playOnAwake = false;

            it.collect = itemSFX;
            it.oAudioSource = src;
            EditorUtility.SetDirty(it);
        }

        AssetDatabase.SaveAssets();
        if (!Application.isPlaying)
        {
            EditorSceneManager.MarkAllScenesDirty();
        }
        Debug.Log("[Antigravity] Sons lifeSFX.mp3 e itemSFX.mp3 vinculados com sucesso!");
    }
}