using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GitBeansUtility 
{






    public static void Open(in IContainGitWebLink link) {
        link.GetGitWebLink(out string path);
        OpenUrl(path);
    }

    public static void Open(in IContainGitFolderPath link) {
        link.GetFolderPath(out string path);
        OpenUrl(path);
    }

    public static void OpenUrl(in string url) {
        Application.OpenURL(url);
    }
}


