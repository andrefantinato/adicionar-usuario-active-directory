using System;
using System.DirectoryServices.AccountManagement;

public class activeDirectoryManage
{
    public bool addUser(string usuario, string senha)
    {
        using (var pc = new PrincipalContext(ContextType.Domain, "pathDomain", "container", "usernameAD", "passwordAD"))
        {
            using (var up = new UserPrincipal(pc))
            {
                try
                {
                    up.SamAccountName = usuario;
                    //é necessário uma conexão ssl
                    up.SetPassword(senha);
                    //outras propriedades
                    //up.Description = "";
                    //up.DisplayName = "";
                    //up.EmailAddress = "";
                    up.Enabled = true;
                    up.Save();

                    return true;
                }
                catch (Exception)
                {
                    Console.Write("error");
                }

            }
        }
        return false;
    }
}