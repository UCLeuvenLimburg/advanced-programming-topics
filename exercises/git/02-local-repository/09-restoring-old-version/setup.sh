#/usr/bin/env bash

rm -rf sandbox
mkdir sandbox
pushd sandbox
git init

echo first > file.txt
git add file.txt
git commit -m 'First commit'

echo second > file.txt
git add file.txt
git commit -m 'Second commit'

echo third > file.txt
git add file.txt
git commit -m 'Third commit'

echo fourth > file.txt
git add file.txt
git commit -m 'Fourth commit'

popd
