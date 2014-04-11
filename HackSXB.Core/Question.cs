using System;
using System.Collections.Generic;
using RestSharp;

namespace HackSXB.Core
{
    public class Question
    {
        public string Title { get; set; }

        public Question ()
        {
            
        }

        public override string ToString()
        {
            return Title;
        }
            
        public delegate void FindXamarinQuestionsCallback(List<Question> questions);
        public static void FindXamarinQuestions(FindXamarinQuestionsCallback done)
        {
            RestClient client = new RestClient("https://api.stackexchange.com/2.2");
            RestRequest request = new RestRequest("/search", Method.GET);

            request.AddParameter("site", "stackoverflow");
            request.AddParameter("tagged", "xamarin");
            request.AddParameter("sort", "activity");
            request.AddParameter("order", "desc");

            request.RootElement = "items";

            client.ExecuteAsync<List<Question>>(request, response =>
            {
                if ( response.StatusCode == System.Net.HttpStatusCode.OK )
                {
                    done(response.Data);
                }
                else
                {
                    done(null);
                }
            });
        }
    }
}

