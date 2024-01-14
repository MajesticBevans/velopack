﻿namespace Velopack.Vpk.Commands;

public class GitHubUploadCommand : GitHubBaseCommand
{
    public bool Publish { get; private set; }

    public string ReleaseName { get; private set; }

    public string TagName { get; private set; }

    public bool Pre { get; private set; }

    public bool Merge { get; private set; }

    public GitHubUploadCommand()
        : base("github", "Upload releases to a GitHub repository.")
    {
        AddOption<bool>((v) => Publish = v, "--publish")
            .SetDescription("Create and publish instead of leaving as draft.");

        AddOption<bool>((v) => Pre = v, "--pre")
            .SetDescription("Create as pre-release instead of stable.");

        AddOption<bool>((v) => Merge = v, "--merge")
            .SetDescription("Allow merging this upload with an existing release.");

        AddOption<string>((v) => ReleaseName = v, "--releaseName")
            .SetDescription("A custom name for the release.")
            .SetArgumentHelpName("NAME");

        AddOption<string>((v) => TagName = v, "--tag")
            .SetDescription("A custom tag for the release.")
            .SetArgumentHelpName("NAME");

        ReleaseDirectoryOption.SetRequired();
        ReleaseDirectoryOption.MustNotBeEmpty();
    }
}
