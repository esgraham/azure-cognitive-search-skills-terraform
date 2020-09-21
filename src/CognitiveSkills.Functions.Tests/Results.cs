// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

namespace CognitiveSkills.Functions.Tests
{
    using System.Collections.ObjectModel;
    using Newtonsoft.Json;

    /// <summary>
    /// Mock of the results returned by Azure Search.
    /// </summary>
    public partial class Results
    {
        private Collection<Value> values = new Collection<Value>();

        /// <summary>
        /// Gets the mock of the results and values collection returned by Azure Search.
        /// </summary>
        [JsonProperty("values")]
        public Collection<Value> Values
        {
            get { return this.values; }
        }
    }
}