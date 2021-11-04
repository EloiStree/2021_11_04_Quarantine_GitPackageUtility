using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GitFolderUtility 
{


    public static void IsPathGitRepository(in string path, out bool isGitPath) {

        int hooks = Directory.GetDirectories(path, "hooks").Length;
        if (hooks < 1) { isGitPath = false; return; }

        int refs = Directory.GetDirectories(path, "refs").Length;
        if (refs < 1) { isGitPath = false; return; }

        int logs = Directory.GetDirectories(path, "logs").Length;
        if (logs < 1) { isGitPath = false; return; }

        int info = Directory.GetDirectories(path, "info").Length;
        if (info < 1) { isGitPath = false; return; }

        isGitPath = true;
    }
}
