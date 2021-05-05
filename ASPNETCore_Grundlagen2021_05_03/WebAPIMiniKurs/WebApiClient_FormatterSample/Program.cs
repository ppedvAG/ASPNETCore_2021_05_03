﻿using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace WebApiClient_FormatterSample
{
    class Program
    {
        static async Task  Main(string[] args)
        {
            string url = "https://localhost:44353/api/contacts";

            HttpClient client = new();
            //client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
            HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, url);
            HttpResponseMessage response = await client.SendAsync(message);
            string xmlText = await response.Content.ReadAsStringAsync();
        }
    }
}
