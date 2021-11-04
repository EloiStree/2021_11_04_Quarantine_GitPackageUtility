using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TDD_IsGitLinkMono : MonoBehaviour
{
    public string m_link;
    public bool m_isGitWebLink;
    public bool m_isSshLink;
    public bool m_isHttpLink;
    public bool m_isFileLink;
    public bool m_hadDotGit;
    public bool m_isGitLab;
    public bool m_isGitHub;

    [ContextMenu("Search")]
    void Search()
    {
        GitWebLinkUtility.IsGitWebLink(in m_link, out m_isGitWebLink);
        GitWebLinkUtility.IsSshLink(in m_link, out m_isSshLink);
        GitWebLinkUtility.IsHttpLink(in m_link, out m_isHttpLink);
        GitWebLinkUtility.IsFileLink(in m_link, out m_isFileLink);
        GitWebLinkUtility.HasDotGitInLink(in m_link, out m_hadDotGit);
        GitWebLinkUtility.HasGitLabCom(in m_link, out m_isGitLab);
        GitWebLinkUtility.HasGitHubCom(in m_link, out m_isGitHub);
    }
    private void OnValidate()
    {
        Search();
    }
}
