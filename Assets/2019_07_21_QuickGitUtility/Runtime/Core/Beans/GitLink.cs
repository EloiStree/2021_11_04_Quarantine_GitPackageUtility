[System.Serializable]
public class GitLink : IContainGitWebLink
{
    
    public string m_gitLink;

    public void GetGitWebLink( out string webLink)
    {
        webLink = m_gitLink;
    }

    public bool IsLinkDefined() { return !string.IsNullOrWhiteSpace(m_gitLink); }
}