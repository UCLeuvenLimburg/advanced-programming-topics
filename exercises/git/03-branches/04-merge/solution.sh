#/usr/bin/env bash

pushd sandbox

git merge feature-1

git merge feature-2

# Resolving conflict; should be done using editor
echo This should be line 1 > file.txt
echo This should be line 3 >> file.txt

git add file.txt
git commit --no-edit

git merge feature-3

echo This should be line 1 > file.txt
echo This should be line 2 >> file.txt
echo This should be line 3 >> file.txt

git add file.txt
git commit --no-edit

git branch -d feature-1
git branch -d feature-2
git branch -d feature-3

popd
