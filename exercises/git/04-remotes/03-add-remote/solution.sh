#/usr/bin/env bash

pushd sandbox

git init local
git init remote --bare

cd local
git remote add origin ../remote

touch file.txt
git add file.txt
git commit -m 'initial commit'
git push -u origin master

popd
