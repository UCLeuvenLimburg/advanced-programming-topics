#/usr/bin/env bash

rm -rf sandbox
mkdir sandbox
pushd sandbox
git init
touch file.txt
git add file.txt
git commit -m 'initial commit'
git branch oak
git branch sycamore
git branch birch
git branch maple
git branch elm
popd
