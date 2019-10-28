#/usr/bin/env bash

rm -rf sandbox
mkdir sandbox
pushd sandbox
git init

touch file.txt
git add file.txt
git commit -m 'initial commit'

git branch feature

touch file2.txt
git add file2.txt
git commit -m 'second file'

git checkout feature
touch file3.txt
git add file3.txt
git commit -m 'third file'

git checkout master

popd
