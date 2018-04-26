using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using DAB_HandIn_3._3.Models;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;

namespace DAB_HandIn_3._3.Repositories
{
    public class PersonRepository
    {
        private DocumentClient _client;
        string databaseName = "PersonKartotekDB";
        string collectionName = "PersonCollection";

        public PersonRepository(DocumentClient client)
        {
            this._client = client;
        }

        public IEnumerable<Person> GetAll()
        {
            IQueryable<Person> query = _client
                .CreateDocumentQuery<Person>(UriFactory.CreateDocumentCollectionUri(databaseName, collectionName));

            List<Person> results = new List<Person>();
            foreach (var person in query)
            {
                results.Add(person);
            }

            return results;
        }

        internal Person Get(string id)
        {
            IQueryable<Person> query = _client
                .CreateDocumentQuery<Person>(UriFactory.CreateDocumentCollectionUri(databaseName, collectionName))
                .Where(p => p.Id == id);

            Person pe = new Person();
            foreach (var person in query)
            {
                pe = person;
            }
            return pe;
        }

        public async void Insert(Person person)
        {
            try
            {
                this._client.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri(databaseName, collectionName),
                    person).Wait();
            }
            catch (Exception e)
            {
                Debug.WriteLine("Cant insert new person: " + e.Message);
            }
        }

        internal async void Put(string id, Person newPerson)
        {
            this._client.ReplaceDocumentAsync(UriFactory.CreateDocumentUri(databaseName, collectionName, id), newPerson).Wait();
        }

        public void Save()
        {
            
        }

        public  async void Delete(string id)
        {
            this._client.DeleteDocumentAsync(UriFactory.CreateDocumentUri(databaseName, collectionName, id)).Wait();
        }
    }
}