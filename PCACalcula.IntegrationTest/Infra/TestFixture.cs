﻿using Bogus;
using System.Net.Http;

namespace PCACalcula.IntegrationTest.Infra
{
    public class TestFixture
    {
        public HttpClient _client;
        public string _urlBase;
        public Faker _faker;
        public string _url;

        public TestFixture()
        {
            _client = new HttpClient();
            _urlBase = "https://localhost:44378";
            _faker = new Faker();
        }
    }
}
