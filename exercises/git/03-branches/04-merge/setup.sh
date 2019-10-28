#/usr/bin/env bash

rm -rf sandbox
mkdir sandbox
pushd sandbox
git init

echo Original line > file.txt
git add file.txt
git commit -m 'Initial commit'

git checkout -b feature-1
echo This should be line 3 > file.txt
git add file.txt
git commit -m 'Feature 1 commit'

git checkout master

git checkout -b feature-2
echo This should be line 1 > file.txt
git add file.txt
git commit -m 'Feature 2 commit'

git checkout master

git checkout -b feature-3
echo This should be line 2 > file.txt
git add file.txt
git commit -m 'Feature 3 commit'

git checkout master

popd
