using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GitFolder : IContainGitFolderPath 
{

    string m_gitRootFolderPath;

    public GitFolder(string gitRootFolderPath)
    {
        m_gitRootFolderPath = gitRootFolderPath;
    }

    public void GetFolderPath(out string folderPath)
    {
        folderPath =  m_gitRootFolderPath;
    }
}
