// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

namespace CognitiveSkills.Functions.Tests
{
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using Microsoft.AspNetCore.Http;
    using Newtonsoft.Json;

    public static class TestFactory
    {
        public static Results CreateValues() => new Results
        {
           Values = new Value[]
            {
                new Value{
                    Data = new Data
                    {
                        Text = "Test"
                    }
                }
            }
        };

        public static Results CreateValues(string textStringValue) => new Results
        {
            Values = new Value[]
            {
                new Value{
                    Data = new Data
                    {
                        Text = textStringValue
                    }
                }
            }
        };

        public static HttpRequest CreateHttpRequest(Results values)
        {
            var json = JsonConvert.SerializeObject(values);

            var context = new DefaultHttpContext();
            var request = context.Request;
            request.Method = "Post";
            request.Body = GenerateStreamFromString(json);

            return request;
        }

        private static MemoryStream GenerateStreamFromString(string value)
        {
            return new MemoryStream(Encoding.UTF8.GetBytes(value ?? string.Empty));
        }
    }
}