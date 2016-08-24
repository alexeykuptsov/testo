import os
import shutil
import subprocess


def main():
    root_dir = os.path.dirname(__file__)
    artifacts_dir = os.path.join(root_dir, 'artifacts')
    sln_path = os.path.join(root_dir, 'src/Testo.sln')
    nuget_path = os.path.join(root_dir, 'tools/NuGet/nuget.exe')
    main_project_path = os.path.join(root_dir, 'src\Testo\Testo.csproj')

    if os.path.isdir(artifacts_dir):
        shutil.rmtree(artifacts_dir)
    os.mkdir(artifacts_dir)

    subprocess.check_call([nuget_path, 'restore', sln_path])

    shutil.copy(os.path.join(os.environ['ASSEMBLY_SIGNING_KEY_HOME'], 'key.snk'),
                os.path.join(root_dir, 'key.snk'))

    msbuild_exec(sln_path)

    subprocess.check_call([
        nuget_path,
        'pack', main_project_path,
        '-Prop', 'Configuration=Release',
        '-Prop', 'Platform=AnyCPU',
        '-OutputDirectory', 'artifacts'
    ])

    nuget_packages_dir = os.path.abspath(os.path.join(root_dir, 'tools/NuGet/packages'))
    subprocess.check_call([
        nuget_path,
        'restore', os.path.join(root_dir, 'tools/NuGet/packages.config'),
        '-o', nuget_packages_dir
    ])

    subprocess.check_call([
        os.path.abspath(os.path.join(nuget_packages_dir, 'NUnit.ConsoleRunner.3.4.1/tools/nunit3-console.exe')),
        os.path.join(root_dir, 'bin/Testo.Tests.dll'),
        '--noresult'
    ], shell=True)


def msbuild_exec(sln_path):
    cmd_args = [
        'C:\\Program Files (x86)\\MSBuild\\14.0\\Bin\\MSBuild.exe',
        sln_path,
        '/p:Configuration=Release',
        '/p:Platform=Any CPU',
        '/p:DefineConstants=STRONG_NAME']
    teamcity_agent_home_dir = os.environ.get("teamcity.agent.home.dir", None)
    if teamcity_agent_home_dir:
        cmd_args.append('/l:JetBrains.BuildServer.MSBuildLoggers.MSBuildLogger,' +
                        os.path.join(teamcity_agent_home_dir,
                                     'plugins/dotnetplugin/bin/JetBrains.BuildServer.MSBuildLoggers.dll'))
    subprocess.check_call(cmd_args)


if __name__ == '__main__':
    main()
