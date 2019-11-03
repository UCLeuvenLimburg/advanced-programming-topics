#/usr/bin/env bash

set -e

rm -rf sandbox
mkdir sandbox
pushd sandbox

git init remote --bare
git init temp

pushd temp
touch file.txt
git add file.txt
git commit -m 'initial commit'

git remote add origin ../remote
git push -u origin master

popd
rm -rf temp

popd
