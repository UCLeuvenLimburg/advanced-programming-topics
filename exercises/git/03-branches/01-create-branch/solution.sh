#/usr/bin/env bash

pushd sandbox
echo a > file.txt
git add file.txt
git commit -m "initial commit"
git branch sidetrack
echo b > file.txt
git add file.txt
git commit -m "sidetrack commit"
popd
