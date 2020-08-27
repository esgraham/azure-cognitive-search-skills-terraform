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

    public class UnitTestCustomSkill
    {
        [Fact]
        public async void Http_trigger_should_return_known_string()
        {
            var values = TestFactory.CreateValues();
            var request = TestFactory.CreateHttpRequest(values);
            var response = (ActionResult<JObject>)await CustomSkill.Run(request);
            Assert.Equal("tseT", response.Value["values"][0]["data"]["reversedText"]);
        }

        [Theory]
        [InlineData("Indianapolis")]
        [InlineData("New York City")]
        public async void Http_trigger_should_return_known_string_from_member_data(string textStringValue)
        {
            var values = TestFactory.CreateValues(textStringValue);
            var request = TestFactory.CreateHttpRequest(values);
            var response = (ActionResult<JObject>)await CustomSkill.Run(request);
            Assert.Equal(new string(response.Value["values"][0]["data"].Value<string>("text").Reverse().ToArray()), response.Value["values"][0]["data"]["reversedText"]);
        }
    }
}
