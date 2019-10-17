#/usr/bin/env bash

rm -rf sandbox
mkdir sandbox
pushd sandbox
git init
echo "You caught me!" >> ampharos.txt
git add ampharos.txt
rm ampharos.txt
popd
