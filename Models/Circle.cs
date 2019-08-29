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
    public class Circle
    {
        public int CircleId { get; set; }
        public string Name { get; set; }
        public string ApplicationUserId { get; set; }

        public ICollection<CircleUserprofile> Userprofiles { get; set; }
        public virtual ApplicationUser Creator { get; set; }

        public static List<Circle> GetAllCircles()
        {
            var client = new RestClient("http://localhost:5000/api/");
            var request = new RestRequest("circles", Method.GET);
            var response = new RestResponse();

            Task.Run(async () =>
            {
                response = await GetAsyncResponse.GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();

            JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(response.Content);
            var circleList = JsonConvert.DeserializeObject<List<Circle>>(jsonResponse.ToString());
            return circleList;
        }

        // Display next page of circles
        // public static List<Circle> GetNextCircles()
        // {
        //     var client = new RestClient("http://localhost:5000/api/");
        //     var request = new RestRequest("circles/next", Method.GET);
        //     var response = new RestResponse();

        //     Task.Run(async () =>
        //     {
        //         response = await GetAsyncResponse.GetResponseContentAsync(client, request) as RestResponse;
        //     }).Wait();

        //     JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(response.Content);
        //     var circleList = JsonConvert.DeserializeObject<List<Circle>>(jsonResponse.ToString());
        //     return circleList;
        // }

        // // Display prev page of circles
        // public static List<Circle> GetPrevCircles()
        // {
        //     var client = new RestClient("http://localhost:5000/api/");
        //     var request = new RestRequest("circles/prev", Method.GET);
        //     var response = new RestResponse();

        //     Task.Run(async () =>
        //     {
        //         response = await GetAsyncResponse.GetResponseContentAsync(client, request) as RestResponse;
        //     }).Wait();

        //     JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(response.Content);
        //     var circleList = JsonConvert.DeserializeObject<List<Circle>>(jsonResponse.ToString());
        //     return circleList;
        // }

        // Display particular circle 
        public static Circle GetThisCircle(int id)
        {
            var client = new RestClient("http://localhost:5000/api/");
            var request = new RestRequest("circles/" + id, Method.GET);
            var response = new RestResponse();

            Task.Run(async () =>
            {
                response = await GetAsyncResponse.GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();

            JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(response.Content);
            var thisCircle = JsonConvert.DeserializeObject<Circle>(jsonResponse.ToString());
            return thisCircle;
        }

        // Add new Circle
        public static void CreateCircle(Circle circle)
        {
            var client = new RestClient("http://localhost:5000/api/");
            var request = new RestRequest("circles", Method.POST);
            request.AddJsonBody(circle);
            var response = new RestResponse();

            Task.Run(async () =>
            {
                response = await GetAsyncResponse.GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();
        }

        // Delete particular Circle
        public static void DeleteCircle(int id)
        {
            var client = new RestClient("http://localhost:5000/api/");
            var request = new RestRequest("circles/" + id, Method.DELETE);
            var response = new RestResponse();

            Task.Run(async () =>
            {
                response = await GetAsyncResponse.GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();
        }

        // Editing a particular Circle
        public static void EditCircle(int id, Circle circle)
        {
            var client = new RestClient("http://localhost:5000/api/");
            var request = new RestRequest("circles/" + id, Method.PUT);
            request.AddJsonBody(circle);
            var response = new RestResponse();

            Task.Run(async () =>
            {
                response = await GetAsyncResponse.GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();
        }

        // Add another user to your circle
        public static void AddUser(int circleId, int userprofileId)
        {
            var client = new RestClient("http://localhost:5000/api/");
            var request = new RestRequest("circles/" + circleId + "/userprofiles/" + userprofileId, Method.POST);
            var response = new RestResponse();

            Task.Run(async () =>
            {
                response = await GetAsyncResponse.GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();
        }
    }
}