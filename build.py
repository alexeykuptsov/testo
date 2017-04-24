import os
import shutil
import subprocess


def main():
    root_dir = os.path.dirname(__file__)
    artifacts_dir = os.path.join(root_dir, 'artifacts')
    sln_path = os.path.join(root_dir, 'src/Testo.sln')

    if os.path.isdir(artifacts_dir):
        shutil.rmtree(artifacts_dir)
    os.mkdir(artifacts_dir)

    subprocess.check_call(['C:\\Program Files (x86)\\Microsoft Visual Studio\\2017\\Community\\Common7\\Tools\\VsDevCmd.bat'])

    subprocess.check_call([
        'dotnet',
        'restore',
        'src\\Testo.sln',
        '/p:Configuration=Release',
        '/p:Platform=Any CPU'
    ])

    shutil.copy(os.path.join(os.environ['ASSEMBLY_SIGNING_KEY_HOME'], 'key.snk'),
                os.path.join(root_dir, 'key.snk'))

    msbuild_exec(sln_path)

    shutil.copy(
        os.path.join(root_dir, 'bin/Testo.1.2.0.nupkg'),
        os.path.join(root_dir, 'artifacts'))

    subprocess.check_call([
        'dotnet',
        'vstest',
        'bin\\netcoreapp1.1\\Testo.Tests.dll'
    ])


def msbuild_exec(sln_path):
    cmd_args = [
        'dotnet',
        'build',
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
