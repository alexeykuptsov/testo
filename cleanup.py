import os
import shutil
import subprocess


def main():
    root_dir = os.path.dirname(__file__)

    dirs_to_remove = [
        os.path.join(root_dir, 'artifacts'),
        os.path.join(root_dir, 'bin'),
        os.path.join(root_dir, 'binDebug'),
        os.path.join(root_dir, 'src/Testo/obj'),
        os.path.join(root_dir, 'src/Testo.Tests/obj'),
        os.path.join(root_dir, 'src/packages'),
        os.path.join(root_dir, 'tools/NuGet/packages')
    ]

    for dir_to_remove in dirs_to_remove:
        if os.path.isdir(dir_to_remove):
            shutil.rmtree(dir_to_remove)

    files_to_remove = [
        os.path.join(root_dir, 'key.snk')
    ]

    for file_to_remove in files_to_remove:
        if os.path.isfile(dir_to_remove):
            os.remove(file_to_remove)


if __name__ == '__main__':
    main()
