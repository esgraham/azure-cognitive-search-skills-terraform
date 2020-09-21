// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

namespace CognitiveSkills.Functions.Tests
{
    using Newtonsoft.Json;

    /// <summary>
    /// Mock of the results and values collection returned by Azure Search.
    /// </summary>
    public partial class Value
    {
        /// <summary>
        /// Gets or Sets the mock of the results and text data returned by Azure Search.
        /// </summary>
        [JsonProperty("data")]
        public ValueData Data { get; set; }
    }
}