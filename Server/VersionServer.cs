using Octokit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Atalhos.Server
{
  public class VersionServer
  {
    
    public string GetLastVersion()
    {
      try
      {
        var ghe = new Uri("https://github.com/viniciusfs15/");
        var client = new GitHubClient(new ProductHeaderValue("Atalhos"), ghe);

        var response = client.Repository.Release.GetLatest("viniciusfs15", "Atalhos").Result;

        // Não deve bloquear a execução do aplicativo
        if (response == null) 
          return GetAppVersion();

        return response.TagName.Replace('v', ' ').Trim();
      }
      catch
      {
        // Não deve bloquear a execução do aplicativo
        return GetAppVersion();
      }
      
    }

    internal string GetAppVersion()
    {
      System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
      System.Diagnostics.FileVersionInfo fvi = System.Diagnostics.FileVersionInfo.GetVersionInfo(assembly.Location);
      return fvi.FileVersion;
    }

    //Valida se a versão do aplicativo é maior que a versão do GitHub
    public bool IsLastVersion()
    {
      var versaoApp = GetAppVersion().Split('.');
      var versaoGitHub = GetLastVersion().Split('.');

      if (Convert.ToInt32(versaoApp[0]) < Convert.ToInt32(versaoGitHub[0]) ||
          (Convert.ToInt32(versaoApp[0]) <= Convert.ToInt32(versaoGitHub[0]) && Convert.ToInt32(versaoApp[1]) < Convert.ToInt32(versaoGitHub[1])) ||
          (Convert.ToInt32(versaoApp[1]) <= Convert.ToInt32(versaoGitHub[1]) && Convert.ToInt32(versaoApp[2]) < Convert.ToInt32(versaoGitHub[2])))
        return false;
      return true;
    }
  }

  internal class GitHubReleaseObj
  {
    public string url { get; set; }
    public string assets_url { get; set; }
    public string upload_url { get; set; }
    public string html_url { get; set; }
    public int id { get; set; }
    public object author { get; set; }
    public string node_id { get; set; }
    public string tag_name { get; set; }
    public string target_commitish { get; set; }
    public string name { get; set; }
    public bool draft { get; set; }
    public bool prerelease { get; set; }
    public DateTime created_at { get; set; }
    public DateTime published_at { get; set; }
    public List<object> assets { get; set; }
    public string tarball_url { get; set; }
    public string zipball_url { get; set; }
    public string body { get; set; }
  }
}
