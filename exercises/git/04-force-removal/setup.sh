#/usr/bin/env bash

rm -rf sandbox
mkdir sandbox
pushd sandbox
git init
echo xyz > file.txt
git add file.txt
echo abc > file.txt
popd
