#
# Copyright (C) 2023 Beru Hinode
#
# SPDX-License-Identifier: GPL-2.0-only
#

# Some preliminary checks regarding sourcing this script.
# Source: https://stackoverflow.com/a/28776166
(
  [[ -n $ZSH_VERSION && $ZSH_EVAL_CONTEXT =~ :file$ ]] ||
  [[ -n $KSH_VERSION && "$(cd -- "$(dirname -- "$0")" && pwd -P)/$(basename -- "$0")" != "$(cd -- "$(dirname -- "${.sh.file}")" && pwd -P)/$(basename -- "${.sh.file}")" ]] ||
  [[ -n $BASH_VERSION ]] && (return 0 2>/dev/null)
) && sourced=1 || sourced=0

# Exit if sourced.
if [ $sourced -eq 1 ]; then
    echo "Do NOT source this script!"
    echo "Example usage: bash dos2unix.sh"
    return 1
fi

# Check if DOS2UNIX is installed and exit if not.
if [ -z "$(which dos2unix)" ]; then
    # Warn that it's not installed and exit.
    echo "dos2unix isn't installed. It's required for this script to work properly."
    echo "If you're on Ubuntu, which is the distro you're supposed to run this script on, install the package using:"
    echo "sudo apt update && sudo apt install dos2unix"
    exit
fi

# Check if Git is installed and exit if not.
if [ -z "$(which git)" ]; then
    # Warn that it's not installed and exit.
    echo "git isn't installed. It's required for this script to work properly."
    echo "If you're on Ubuntu, which is the distro you're supposed to run this script on, install the package using:"
    echo "sudo apt update && sudo apt install git"
    exit
fi

# Try to parse top level of repo.
topLevel="$(git rev-parse --show-toplevel 2>/dev/null)"

if [ -z "$topLevel" ]; then
    # Warn that the user didn't execute it from a Git repo and exit.
    echo "You're not in a Git repository. Run this script from within one."
    exit
fi

# Go to top of the repo.
cd "$topLevel"

# Run dos2unix for all files within the repo.
for i in $(find -type f); do
     dos2unix $i
done

# Let's commit it now!
git add .
if [ -z "$(git diff-index --quiet HEAD)" ]; then
    git commit -s -m "[Beru no CI] CE100-HW1: Switch all files to UNIX format"
    git push
fi

# We're done here!
echo "All done!"
