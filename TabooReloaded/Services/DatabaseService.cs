using Google.Apis.Auth.OAuth2;
using Google.Cloud.Firestore;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using TabooReloaded.Shared.Model;
using TabooReloaded.Shared.Services;

namespace TabooReloaded.Services
{
    public class DatabaseService : IDatabaseService
    {
        private readonly IConfiguration _config;
        private CollectionReference CollectionRef { get; set; }

        private QuerySnapshot QuerySnapshot { get; set; }
        private bool IsConnected { get; set; }

        public DatabaseService(IConfiguration config)
        {
            _config = config;

            string jsonData = SecretsManager.Secrets.GetCredentials();

            GoogleCredential credential = GoogleCredential.FromJson(jsonData);

            FirestoreDbBuilder fsBuilder = new FirestoreDbBuilder
            {
                ProjectId = _config["ProjectId"],
                DatabaseId = _config["DatabaseId"],
                Credential = credential
            };
            FirestoreDb db = fsBuilder.Build();

            CollectionRef = db.Collection("TabooWords");
        }

        public async Task<bool> ConnectAsync()
        {
            try
            {
                QuerySnapshot = await CollectionRef.GetSnapshotAsync();
                if(QuerySnapshot.Documents.Count == 0)
                {
                    throw new Exception("No taboo words found");
                }
                IsConnected = true;
                return await Task.FromResult(true);
            }
            catch (Exception)
            {
                return await Task.FromResult(false);
            }
        }

        public Task<bool> DisconnectAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<TabooWordModel> GetTabooWordAsync()
        {
            TabooWordModel result = new TabooWordModel();
            if(IsConnected)
            {
                var doc = QuerySnapshot.Documents.First();
                result = doc.ConvertTo<TabooWordModel>();
            }

            return result;
        }

        public Task GetTabooWordListAsync(int n)
        {
            throw new NotImplementedException();
        }
    }
}
