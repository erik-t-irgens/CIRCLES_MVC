using Microsoft.AspNetCore.Identity;
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
    public class ApplicationUser : IdentityUser
    {
        public static void Register(ApplicationUser applicationuser)
        {
            var client = new RestClient("http://localhost:5000/api/");
            var request = new RestRequest("applicationuser", Method.POST);
            request.AddJsonBody(applicationuser);
            var response = new RestResponse();

            Task.Run(async () =>
            {
                response = await GetAsyncResponse.GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();
        }

    }
}