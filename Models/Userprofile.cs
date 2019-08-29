using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.EntityFrameworkCore;

using System.Threading.Tasks;

namespace Circles_MVC.Models
{

    public class Userprofile
    {
        public int UserprofileId { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string Bio { get; set; }
        public string Photo { get; set; }
        public string Location { get; set; }
        public string ApplicationUserId { get; set; }

        public ICollection<TagUserprofile> Tags { get; set; }
        public ICollection<CircleUserprofile> Circles { get; set; }


        public static void CreateUserProfile(Userprofile userprofile)
        {
            var client = new RestClient("http://localhost:5000/api/");
            var request = new RestRequest("userprofiles/", Method.POST);
            request.AddJsonBody(userprofile);
            var response = new RestResponse();

            Task.Run(async () =>
            {
                response = await GetAsyncResponse.GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();
        }

        public static List<Userprofile> GetAllUserprofilesFirst()
        {
            var client = new RestClient("http://localhost:5000/api/");
            var request = new RestRequest("userprofiles/first", Method.GET);
            var response = new RestResponse();

            Task.Run(async () =>
            {
                response = await GetAsyncResponse.GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();

            Console.WriteLine(response);
            JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(response.Content);
            var userprofileList = JsonConvert.DeserializeObject<List<Userprofile>>(jsonResponse.ToString());
            return userprofileList;
        }

        public static List<Userprofile> GetAllUserprofilesNext()
        {
            var client = new RestClient("http://localhost:5000/api/");
            var request = new RestRequest("userprofiles/next", Method.GET);
            var response = new RestResponse();

            Task.Run(async () =>
            {
                response = await GetAsyncResponse.GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();

            Console.WriteLine(response);
            JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(response.Content);
            var userprofileList = JsonConvert.DeserializeObject<List<Userprofile>>(jsonResponse.ToString());
            return userprofileList;
        }

        public static List<Userprofile> GetAllUserprofilesPrev()
        {
            var client = new RestClient("http://localhost:5000/api/");
            var request = new RestRequest("userprofiles/prev", Method.GET);
            var response = new RestResponse();

            Task.Run(async () =>
            {
                response = await GetAsyncResponse.GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();

            Console.WriteLine(response);
            JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(response.Content);
            var userprofileList = JsonConvert.DeserializeObject<List<Userprofile>>(jsonResponse.ToString());
            return userprofileList;
        }



        public static Userprofile GetThisUserprofile(int id)
        {
            var client = new RestClient("http://localhost:5000/api/");
            var request = new RestRequest("userprofiles/" + id, Method.GET);
            var response = new RestResponse();

            Task.Run(async () =>
            {
                response = await GetAsyncResponse.GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();

            JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(response.Content);
            var thisUserprofile = JsonConvert.DeserializeObject<Userprofile>(jsonResponse.ToString());
            return thisUserprofile;
        }
        public static void EditUserprofile(int id, Userprofile userprofile)
        {
            var client = new RestClient("http://localhost:5000/api/");
            var request = new RestRequest("userprofiles/" + id, Method.PUT);
            request.AddJsonBody(userprofile);
            var response = new RestResponse();

            Task.Run(async () =>
            {
                response = await GetAsyncResponse.GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();
        }



    }


}