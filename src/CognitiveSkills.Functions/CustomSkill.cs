// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

namespace CognitiveSkills.Functions
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Extensions.Http;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// Custom Skill to be used with Azure Search.  Takes the text value in the search results and reverses the text.
    /// </summary>
    public static class CustomSkill
    {
        /// <summary>
        /// The method that runs the HTTP Triggered function.
        /// </summary>
        /// <param name="req">The HTTP Requst from the trigger.</param>
        /// <returns>Returns a Json Object.</returns>
        [FunctionName(nameof(CustomSkill))]
        public static async Task<ActionResult<JObject>> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req)
            {
            if (req == null)
            {
                throw new ArgumentNullException(nameof(req));
            }

            using var streamReader = new StreamReader(req.Body);
            var requestString = await streamReader.ReadToEndAsync().ConfigureAwait(false);
            var requestJson = JsonConvert.DeserializeObject<JObject>(requestString);
            foreach (var value in requestJson["values"])
            {
                value["data"]["reversedText"] = new string(value["data"].Value<string>("text").Reverse().ToArray());
            }

            return requestJson;
        }
    }
}