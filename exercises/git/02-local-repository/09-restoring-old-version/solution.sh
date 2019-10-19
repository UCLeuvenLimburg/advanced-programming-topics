#/usr/bin/env bash

pushd sandbox > /dev/null
git checkout HEAD~2 file.txt
popd > /dev/null
