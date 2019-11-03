#/usr/bin/env bash

rm -rf sandbox
mkdir sandbox
pushd sandbox

git init local
git init remote --bare

pushd local

git remote add origin ../remote

touch file.txt
git add file.txt
git commit -m 'initial commit'
git push -u origin master

git checkout -b branch-a
echo a > file.txt
git add file.txt
git commit -m 'commit in branch a'
git push -u origin branch-a

git checkout master
git checkout -b branch-b
echo b > file.txt
git add file.txt
git commit -m 'commit in branch b'
git push -u origin branch-b

git checkout master
git checkout -b branch-c
echo c > file.txt
git add file.txt
git commit -m 'commit in branch c'
git push -u origin branch-c

popd

rm -rf local
git init local

popd
