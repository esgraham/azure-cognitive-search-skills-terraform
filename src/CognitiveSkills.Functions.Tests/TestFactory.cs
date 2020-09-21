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

            DefaultHttpContext defaultHttpContext = new DefaultHttpContext
            {
                Request = {
                Method = "POST",
                Body = GenerateStreamFromString(json),
                }  
            };

            return defaultHttpContext.Request;
        }

        private static MemoryStream GenerateStreamFromString(string value)
        {
            return new MemoryStream(Encoding.UTF8.GetBytes(value ?? string.Empty));
        }
    }
}