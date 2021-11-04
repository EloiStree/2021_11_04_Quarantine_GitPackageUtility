using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class GitWebLinkUtility
{


    public static void IsGitWebLink(in string link, out bool isGitWebLink) {

        isGitWebLink = Regex.Match(link, "((git|ssh|http(s)?)|(git@[\\w\\.]+))(:(//)?)([\\w\\.@\\:/\\-~]+)(\\.git)(/)?").Success;
    }

    //git@gitlab.com:eloistree/aerez.git
    //git@github.com:EloiStree/EloiStree.git
    public static void IsSshLink(in string link, out bool isSSH)
    {
        HasDotGitInLink(in link, out bool hasGit);
        if (!hasGit) {
            isSSH = false;
            return;
        }
        
        isSSH = Regex.Match(link, "((@[\\w\\.]+))(:(//)?)([\\w\\.@\\:/\\-~]+)(\\.git)(/)?").Success;

    }

    //https://github.com/EloiStree/EloiStree.git
    //https://gitlab.com/eloistree/2021_07_26_public_eloistreecv.git
    public static void IsHttpLink(in string link, out bool ishtml)
    {
        StartWithHttpGitInLink(in link, out bool startHtml);
        if (!startHtml)
        {
            ishtml = false;
            return;
        }
        HasDotGitInLink(in link, out ishtml);

    }

    public static void HasDotGitInLink(in string link, out bool hasDotLink)
    {
        hasDotLink = link.ToLower().IndexOf(".git", System.StringComparison.OrdinalIgnoreCase) > -1;
    }
    public static void StartWithHttpGitInLink(in string link, out bool startWithHttp)
    {

        startWithHttp = link.ToLower().Trim().IndexOf("http", System.StringComparison.OrdinalIgnoreCase) == 0;
    }

    public static void IsFileLink(in string link, out bool isFileLink)
    {
        StartWithFileGitInLink(in link, out bool startFile);
        if (!startFile) { 
            isFileLink = false;
            return;
        }
        HasDotGitInLink(in link, out isFileLink);
    }
    public static void StartWithFileGitInLink(in string link, out bool startWithFile)
    {
        startWithFile = link.ToLower().IndexOf("file:", System.StringComparison.OrdinalIgnoreCase)== 0;
    }

    public static void HasGitHubCom(in string link, out bool hasGitHub) {
        hasGitHub = link.ToLower().IndexOf("github.com") > -1;
    }
    public static void HasGitLabCom(in string link, out bool hasGitLab)
    {
        hasGitLab = link.ToLower().IndexOf("gitlab.com") > -1;
    }
}


/*Git Link possibilities
 * ssh://user@host.xz:port/path/to/repo.git/
* ssh://user@host.xz/path/to/repo.git/
* ssh://host.xz:port/path/to/repo.git/
* ssh://host.xz/path/to/repo.git/
* ssh://user@host.xz/path/to/repo.git/
* ssh://host.xz/path/to/repo.git/
* ssh://user@host.xz/~user/path/to/repo.git/
* ssh://host.xz/~user/path/to/repo.git/
* ssh://user@host.xz/~/path/to/repo.git
* ssh://host.xz/~/path/to/repo.git
* user@host.xz:/path/to/repo.git/
* host.xz:/path/to/repo.git/
* user@host.xz:~user/path/to/repo.git/
* host.xz:~user/path/to/repo.git/
* user@host.xz:path/to/repo.git
* host.xz:path/to/repo.git
* rsync://host.xz/path/to/repo.git/
* git://host.xz/path/to/repo.git/
* git://host.xz/~user/path/to/repo.git/
* http://host.xz/path/to/repo.git/
* https://host.xz/path/to/repo.git/
* /path/to/repo.git/
* path/to/repo.git/
* ~/path/to/repo.git
* file:///path/to/repo.git/
* file://~/path/to/repo.git/
 */