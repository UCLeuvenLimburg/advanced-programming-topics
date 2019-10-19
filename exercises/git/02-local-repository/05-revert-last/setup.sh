#/usr/bin/env bash

rm -rf sandbox
mkdir sandbox
pushd sandbox
git init

echo first > file.txt
git add file.txt
git commit -m 'first commit'

echo second > file.txt
git add file.txt
git commit -m 'second commit'

echo third > file.txt
git add file.txt
git commit -m 'third commit'

echo fourth > file.txt
git add file.txt
git commit -m 'fourth commit'

popd
