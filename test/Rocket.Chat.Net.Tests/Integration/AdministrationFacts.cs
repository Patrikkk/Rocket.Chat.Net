﻿namespace Rocket.Chat.Net.Tests.Integration
{
    using System.Threading.Tasks;

    using FluentAssertions;

    using Rocket.Chat.Net.Tests.Helpers;

    using Xunit;
    using Xunit.Abstractions;

    public class AdministrationFacts : DriverFactsBase
    {
        public AdministrationFacts(ITestOutputHelper helper) : base(helper)
        {
        }

        [Fact]
        public async Task Version_should_be_compatible()
        {
            // This isn't really a test.
            // It's here for my own record keeping, 
            //  if something breaks I'll know the last good version from
            //  test/git history

            var supportedVersions = new[]
            {
                "0.22.0"
            };

            await DefaultAccountLogin();

            // Act
            var results = await RocketChatDriver.GetStatisticsAsync();

            XUnitLogger.Info(results.ToString());

            // Assert
            supportedVersions.Should().Contain(results.Result.Version);
        }
    }
}