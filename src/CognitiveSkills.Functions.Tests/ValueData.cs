// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

namespace CognitiveSkills.Functions.Tests
{
    using Newtonsoft.Json;

    /// <summary>
    /// Mock of the results and data returned by Azure Search.
    /// </summary>
    public partial class ValueData
    {
        /// <summary>
        /// Gets or Sets the reversed text value.
        /// </summary>
        [JsonProperty("reversedText")]
        public string ReversedText { get; set; }

        /// <summary>
        /// Gets or Sets the text value.
        /// </summary>
        [JsonProperty("text")]
        public string Text { get; set; }
    }
}