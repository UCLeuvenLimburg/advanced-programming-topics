#/usr/bin/env bash

pushd sandbox

echo a > file.txt
git add file.txt
git commit -m "initial commit"

echo b > file.txt
git add file.txt
git commit -m "shared commit"

git branch sidetrack

echo c > file.txt
git add file.txt
git commit -m "master specific"

git checkout sidetrack

echo d > file.txt
git add file.txt
git commit -m "sidetrack specific"

popd
