// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

namespace CognitiveSkills.Functions.Tests
{
    using System.Collections.ObjectModel;
    using System.IO;
    using System.Text;
    using Microsoft.AspNetCore.Http;
    using Newtonsoft.Json;

    /// <summary>
    /// The test factory to create the mock values of the Azure Search results.
    /// </summary>
    public static class TestFactory
    {
        private static string teststring = "Test";

        /// <summary>
        /// Create a mock Azure Search Value with a set value.
        /// </summary>
        /// <returns>Returns a Results Object.</returns>
        public static Results CreateValues()
        {
            Value value = new Value
            {
                Data = new ValueData
                {
                    Text = teststring,
                },
            };

            Results results = new Results();
            results.Values.Add(value);

            return results;
        }

        /// <summary>
        /// Create a mock Azure Search Value with an incoming value.
        /// </summary>
        /// <param name="textStringValue">The text string assigned to the text property.</param>
        /// <returns>Returns a Results Object.</returns>
        public static Results CreateValues(string textStringValue)
        {
            Value value = new Value
            {
                Data = new ValueData
                {
                    Text = textStringValue,
                },
            };

            Results results = new Results();
            results.Values.Add(value);

            return results;
        }

        /// <summary>
        /// Create the HTTP Request that calls the Azure Function.
        /// </summary>
        /// <param name="values">The Results object containing the text property.</param>
        /// <returns>Returns an HTTP Request.</returns>
        public static HttpRequest CreateHttpRequest(Results values)
        {
            var json = JsonConvert.SerializeObject(values);

            DefaultHttpContext defaultHttpContext = new DefaultHttpContext
            {
                Request =
                {
                    Method = "POST",
                    Body = GenerateStreamFromString(json),
                },
            };

            return defaultHttpContext.Request;
        }

        /// <summary>
        /// Generate a Stream from a string value.
        /// </summary>
        /// <param name="value">The string value to convert into a stream.</param>
        /// <returns>Returns a MemoryStream of the string.</returns>
        private static MemoryStream GenerateStreamFromString(string value)
        {
            return new MemoryStream(Encoding.UTF8.GetBytes(value ?? string.Empty));
        }
    }
}