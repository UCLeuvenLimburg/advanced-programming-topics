#/usr/bin/env bash

rm -rf sandbox
mkdir sandbox
pushd sandbox
git init
head /dev/urandom > a.txt
head /dev/urandom > b.txt
head /dev/urandom > c.txt
head /dev/urandom > d.txt
git add .
git commit -m "commit 1"
head /dev/urandom > a.txt
head /dev/urandom > c.txt
head /dev/urandom > d.txt
git add .
git commit -m "commit 2"
head /dev/urandom > c.txt
head /dev/urandom > d.txt
git add .
git commit -m "commit 3"
head /dev/urandom > a.txt
head /dev/urandom > b.txt
git add .
git commit -m "commit 4"
head /dev/urandom > b.txt
head /dev/urandom > d.txt
git add .
git commit -m "commit 5"
popd
