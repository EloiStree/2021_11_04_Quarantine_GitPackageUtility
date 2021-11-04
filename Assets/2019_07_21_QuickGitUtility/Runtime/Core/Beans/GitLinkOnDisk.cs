
using System.IO;
using UnityEngine;

[System.Serializable]
public class GitLinkOnDisk : GitLink
{
    public string m_projectDirectoryPath;
    public GitLinkOnDisk(string directoryPath)
    {
        QuickGit.GetGitUrl(directoryPath,out m_gitLink);
        this.m_projectDirectoryPath = directoryPath;
    }

    public void OpenFolder()
    {
        if (Directory.Exists(m_projectDirectoryPath))
            Application.OpenURL(m_projectDirectoryPath);
    }
    public void OpenHost()
    {
            Application.OpenURL(m_gitLink);
    }
    public bool IsPathDefined() { return !string.IsNullOrWhiteSpace(m_projectDirectoryPath); }

    public string GetDirectoryPath()
    {
        return m_projectDirectoryPath;
    }

    public bool IsInsideUnityProject() {
       return  QuickGit.IsGitInsideProject(m_projectDirectoryPath);
    }
    public bool IsOutsideUnityProject() {
        return !IsInsideUnityProject();
    }

    public bool Exist()
    {
        return Directory.Exists(m_projectDirectoryPath) && Directory.Exists(m_projectDirectoryPath+"/.git");
    }

    public string GetUrl()
    {
        return m_gitLink;
    }

    public string GetName()
    {
        int indexOf = m_gitLink.LastIndexOf("/");
        if (indexOf < 0)
            indexOf = m_gitLink.LastIndexOf("\\");
        if (indexOf < 0)
            indexOf = 0;
        return m_gitLink.Substring(indexOf).Replace(".git", "")
            .Replace("/", "").Replace("\\", "");
    }

    public bool IsHosted()
    {
        return m_gitLink != null && m_gitLink.Length > 0;
    }

    public GitServer GetServerType()
    {
        return DownloadInfoFromGitServer.GetServerTypeOfPath(m_gitLink);
    }

    public bool HasUrl()
    {
        return IsHosted();
    }

    public string GetRelativeDirectoryPath()
    {
       string up= Directory.GetCurrentDirectory().Replace("\\","/");
       string ap = m_projectDirectoryPath.Replace("\\", "/");
        string result = ap.Replace(up, "");
        if (result.Length>0 && 
            (result[0] == '/' || result[0] == '\\') )
            return result.Substring(1);
        return result;
    }

    public string GetLastRevision()
    {
        bool found;
        string value;
        QuickGit.GetLastRevision(m_projectDirectoryPath, out found, out value);
        return value;
    }
    public string GetLastRevision(out bool found)
    {
        string value;
        QuickGit.GetLastRevision(m_projectDirectoryPath, out found, out value);
        return value;
    }
}


