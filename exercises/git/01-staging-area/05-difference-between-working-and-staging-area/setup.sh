#/usr/bin/env bash

rm -rf sandbox
mkdir sandbox
pushd sandbox
git init
echo a > file.txt
echo b >> file.txt
echo c >> file.txt
echo d >> file.txt
git add file.txt
echo a > file.txt
echo b >> file.txt
echo x >> file.txt
echo d >> file.txt
popd
