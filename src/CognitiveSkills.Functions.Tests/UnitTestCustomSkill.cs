// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

namespace CognitiveSkills.Functions.Tests
{
    using System;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Xunit;

    /// <summary>
    /// The Unit Tests of the Azure Function that is used as an Azure Search Custom Skill.
    /// </summary>
    public class UnitTestCustomSkill
    {
        /// <summary>
        /// Call Azure Function and the returned value is the specified string.
        /// </summary>
        [Fact]
        public async void HttpTriggerShouldReturnKnownString()
        {
            var values = TestFactory.CreateValues();
            var request = TestFactory.CreateHttpRequest(values);
            var response = (ActionResult<JObject>)await CustomSkill.Run(request).ConfigureAwait(false);
            Assert.Equal("seT", response.Value["values"][0]["data"]["reversedText"]);
        }

        /// <summary>
        /// Call Azure Function and evaluate the reversed text based on the incoming string value.
        /// </summary>
        /// <param name="textStringValue">The text string assigned to the text property.</param>
        [Theory]
        [InlineData("Indianapolis")]
        [InlineData("New York City")]
        public async void HttpTriggerShouldReturnKnownStringfromMemberData(string textStringValue)
        {
            var values = TestFactory.CreateValues(textStringValue);
            var request = TestFactory.CreateHttpRequest(values);
            var response = (ActionResult<JObject>)await CustomSkill.Run(request).ConfigureAwait(false);
            Assert.Equal(new string(response.Value["values"][0]["data"].Value<string>("text").Reverse().ToArray()), response.Value["values"][0]["data"]["reversedText"]);
        }
    }
}
