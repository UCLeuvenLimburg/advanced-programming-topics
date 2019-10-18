#/usr/bin/env bash

pushd sandbox
echo a > file.txt
git add file.txt
git commit -m "Initial commit"
popd
