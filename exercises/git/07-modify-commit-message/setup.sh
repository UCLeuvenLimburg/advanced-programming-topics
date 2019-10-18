#/usr/bin/env bash

rm -rf sandbox
mkdir sandbox
pushd sandbox
git init
touch file.txt
git add file.txt
git commit -m "Wrong message"
popd
