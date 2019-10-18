#/usr/bin/env bash

rm -rf sandbox
mkdir sandbox
pushd sandbox
git init

git config author.name John
openssl rand -base64 40 > file.txt
openssl rand -base64 40 > file.txt
openssl rand -base64 40 > file.txt
openssl rand -base64 40 > file.txt
git add file.txt
git commit -m 'update'

git config author.name Sophie
openssl rand -base64 40 >> file.txt
openssl rand -base64 40 >> file.txt
openssl rand -base64 40 >> file.txt
git add file.txt
git commit -m 'update'

git config author.name Jack
openssl rand -base64 40 >> file.txt
openssl rand -base64 40 >> file.txt
openssl rand -base64 40 >> file.txt
openssl rand -base64 40 >> file.txt
openssl rand -base64 40 >> file.txt
git add file.txt
git commit -m 'update'

git config author.name James
openssl rand -base64 40 >> file.txt
openssl rand -base64 40 >> file.txt
openssl rand -base64 40 >> file.txt
openssl rand -base64 40 >> file.txt
openssl rand -base64 40 >> file.txt
openssl rand -base64 40 >> file.txt
openssl rand -base64 40 >> file.txt
git add file.txt
git commit -m 'update'

popd
