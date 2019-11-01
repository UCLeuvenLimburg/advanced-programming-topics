#/usr/bin/env bash

rm -rf sandbox
mkdir sandbox
pushd sandbox

git init local
git init remote --bare

popd
