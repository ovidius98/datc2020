using System;
using System.IO;
using System.Threading;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;

namespace Datc_tema3_googleDrive
{
    class Program
    {    static string[] Scopes = { DriveService.Scope.Drive };
        static string ApplicationName = "Datc Tema 3";
        static DriveService service1;
        static void Main(string[] args)
        {
            Initializare();
        }

         static void   Initializare(){
              UserCredential credential;

            using (var stream =
                new FileStream("datc_client_JSON.json", FileMode.Open, FileAccess.Read))
            {
                // The file token.json stores the user's access and refresh tokens, and is created
                // automatically when the authorization flow completes for the first time.
                string credPath = "token";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    Environment.UserName,
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                Console.WriteLine("Credential file saved to: " + credPath);
            }
 
            // Create Drive API service.
            service1 = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            static void GetAllFiles(){
                
            }
         }
    }
}
