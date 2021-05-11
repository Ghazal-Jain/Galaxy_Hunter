/* 
	Stick Crafter Junkyard
 	Create Folder Structure Script
*/

using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class CreateFolderStructure : ScriptableWizard
{

    public string FolderName = "Game";
    private string SFGUID;
    List<string> folders = new List<string>() { "Art", "Scripts", "Resources", "Scenes", "Prefabs" };
    List<string> ArtFolders = new List<string>() { "Animation", "Audio", "Fonts", "Materials", "Objects", "Textures" };
    List<string> scriptsFolders = new List<string>() { "Core", "Editor", "Shaders" };
    List<string> resourcesFolders = new List<string>() { "Characters", "Managers", "Props", "UI" };

    [MenuItem("StickCrafter/Create Project Folders")]
    static void CreateWizard()
    {
        ScriptableWizard.DisplayWizard("Create Project Folders", typeof(CreateFolderStructure), "Create");
    }

    //Called when the window first appears
    void OnEnable()
    {

    }
    //Create button click
    void OnWizardCreate()
    {
        // creates the primary folder for game
        string primaryFolder = AssetDatabase.CreateFolder("Assets", FolderName);

        //create all the folders required in a project
        foreach (string folder in folders)
        {
            string guid = AssetDatabase.CreateFolder("Assets/" + FolderName, folder);
            string newFolderPath = AssetDatabase.GUIDToAssetPath(guid);
            if (folder == "Scripts")
                SFGUID = newFolderPath;
        }

        AssetDatabase.Refresh();

        foreach (string art in ArtFolders)
        {
            //AssetDatabase.Contain
            string guid = AssetDatabase.CreateFolder("Assets/" + FolderName + "/Art", art);
            string newFolderPath = AssetDatabase.GUIDToAssetPath(guid);

        }

        AssetDatabase.Refresh();

        foreach (string script in scriptsFolders)
        {
            //AssetDatabase.Contain
            string guid = AssetDatabase.CreateFolder("Assets/" + FolderName + "/Scripts", script);
            string newFolderPath = AssetDatabase.GUIDToAssetPath(guid);

        }

        AssetDatabase.Refresh();

        foreach (string resource in resourcesFolders)
        {
            //AssetDatabase.Contain
            string guid = AssetDatabase.CreateFolder("Assets/" + FolderName + "/Resources", resource);
            string newFolderPath = AssetDatabase.GUIDToAssetPath(guid);

        }

    }
}