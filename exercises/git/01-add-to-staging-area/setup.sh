#/usr/bin/env bash

rm -rf sandbox
mkdir sandbox
pushd sandbox
git init
touch a.txt
popd
