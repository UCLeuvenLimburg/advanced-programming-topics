#/usr/bin/env bash

rm -rf sandbox
mkdir sandbox
pushd sandbox
git init
echo "azer1234" >> password.txt
git add password.txt
popd
