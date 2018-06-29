﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using SpotLightUWP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotLightUWP.Services
{
   public class HTTPService
    {
        RestClient client = new RestClient("http://spotlight.gear.host/imageuri");


        public List<ImageDTO> URLParser()
        {
            List<ImageDTO> ImageDtos = new List<ImageDTO>();

            var request = new RestRequest(Method.GET);
            
            var queryResult = client.Execute(request);

            if (queryResult.StatusCode == System.Net.HttpStatusCode.OK)
            {
                JObject o = JObject.Parse(queryResult.Content);
                JArray images = (JArray)o.SelectToken("Images");

                foreach (var item in images)
                {
                    ImageDtos.Add(JsonConvert.DeserializeObject<ImageDTO>(item.ToString()));
                }
                return ImageDtos;
            }

            else return null;
        }

        public int UpdatedDate()
        {
            var request = new RestRequest(Method.GET);
            var queryResult = client.Execute(request);

            if (queryResult.StatusCode == System.Net.HttpStatusCode.OK)
            {
                JObject o = JObject.Parse(queryResult.Content);

                return (int)o.SelectToken("Meta.Date");
            }
            return 0;
        }

    }
}
