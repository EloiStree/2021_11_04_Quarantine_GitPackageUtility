using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class TDD_GetGitRootsInFolderPath : MonoBehaviour
{
    public string m_folderTarget;
    public string [] m_foldersTarget;


    [Header("Current")]
    public bool m_isCurrentGit;

    [Header("Childrens")]
    public string [] m_foldersIn;
    public string [] m_foldersThatCouldBeGit;
    public string [] m_foldersThatAreGit;
    public List<string> m_folderExploration = new List<string>();


    [Header("Parent")]
    public string [] m_foldersUp;

    [ContextMenu("Search")]
    public void Search()    
    {
        E_DirectoryExplorationUtility.GetParentsPathFromPathToRoot(in m_folderTarget, out m_foldersUp,false);

        E_DirectoryExplorationUtility.ExploreFolderWithCondition(in m_folderTarget, ref m_folderExploration, StopCondition, ShouldItBeAdded);

       
    }

    public void StopCondition(in string nextFolderPath, out bool continueToExplore)
    {
        if (nextFolderPath.EndsWith(".git", System.StringComparison.OrdinalIgnoreCase))
        {
            continueToExplore = false;
            return;
        }
        if (nextFolderPath.EndsWith("temp", System.StringComparison.OrdinalIgnoreCase))
        {
            continueToExplore = false;
            return;
        }
        continueToExplore = true;
    }
    public void ShouldItBeAdded(in string targetFolder, out bool addThePath)
    {
        m_foldersTarget = Directory.GetDirectories(m_folderTarget, "*.git*");
        if (targetFolder.IndexOf(".git") < 0) {
            addThePath = false;
            return;
        }
        GitFolderUtility.IsPathGitRepository(in targetFolder, out addThePath);
    }

}
