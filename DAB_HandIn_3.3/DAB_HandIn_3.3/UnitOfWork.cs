
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using DAB_HandIn_3._3.Repositories;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;

namespace DAB_HandIn_3._3
{
    public class UnitOfWork
    {
        private DocumentClient _client;
        private const string _endPointURL = "https://localhost:8081";
        private const string _primaryKey = "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";

        private PersonRepository _personRepository;
        public PersonRepository PersonRepository => _personRepository ?? (_personRepository = new PersonRepository(_client));

        string databaseName = "PersonKartotekDB";
        string collectionName = "PersonCollection";

        public UnitOfWork()
        {
            Connect().Wait();
        }

        public async Task Connect()
        {
            try
            {
                this._client = new DocumentClient(new Uri(_endPointURL), _primaryKey);
                this._client.CreateDatabaseIfNotExistsAsync(new Database { Id = databaseName }).Wait();
                this._client.CreateDocumentCollectionIfNotExistsAsync(UriFactory.CreateDatabaseUri(databaseName),
                    new DocumentCollection { Id = collectionName }).Wait();
            }
            catch (DocumentClientException de)
            {
                Exception baseException = de.GetBaseException();
                Debug.WriteLine("{0} error occurred: {1}, Message: {2}", de.StatusCode, de.Message, baseException.Message);
            }
            catch (Exception e)
            {
                Exception baseException = e.GetBaseException();
                Debug.WriteLine("Error: {0}, Message: {1}", e.Message, baseException.Message);
            }
            finally
            {
                Debug.WriteLine("Connection == true");
            }
        }

        public void Save() => PersonRepository.Save();
    }

}