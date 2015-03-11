﻿//-----------------------------------------------------------------------
// <copyright file="ReleaseNotesBuilderIntegrationTests.cs" company="gep13">
//     Copyright (c) gep13. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace GitHubReleaseManager.Tests
{
    using System;
    using System.Diagnostics;
    using GitHubReleaseManager;
    using GitHubReleaseManager.Configuration;
    using GitHubReleaseManager.Helpers;
    using NUnit.Framework;

    [TestFixture]
    public class ReleaseNotesBuilderIntegrationTests
    {
        [Test]
        [Explicit]
        public async void SingleMilestone()
        {
            var gitHubClient = ClientBuilder.Build();
            var fileSystem = new FileSystem();
            var currentDirectory = Environment.CurrentDirectory;
            var configuration = ConfigurationProvider.Provide(currentDirectory, fileSystem);

            var releaseNotesBuilder = new ReleaseNotesBuilder(new DefaultGitHubClient(gitHubClient, "Particular", "NServiceBus"), "Particular", "NServiceBus", "5.1.0", configuration);
            var result = await releaseNotesBuilder.BuildReleaseNotes();
            Debug.WriteLine(result);
            ClipBoardHelper.SetClipboard(result);
        }

        [Test]
        [Explicit]
        public async void SingleMilestone3()
        {
            var gitHubClient = ClientBuilder.Build();
            var fileSystem = new FileSystem();
            var currentDirectory = Environment.CurrentDirectory;
            var configuration = ConfigurationProvider.Provide(currentDirectory, fileSystem);

            var releaseNotesBuilder = new ReleaseNotesBuilder(new DefaultGitHubClient(gitHubClient, "Particular", "ServiceControl"), "Particular", "ServiceControl", "1.0.0-Beta4", configuration);
            var result = await releaseNotesBuilder.BuildReleaseNotes();
            Debug.WriteLine(result);
            ClipBoardHelper.SetClipboard(result);
        }

        [Test]
        [Explicit]
        public void OctokitTests()
        {
            ClientBuilder.Build();
        }
    }
}