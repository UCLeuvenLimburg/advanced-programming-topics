#/usr/bin/env bash

pushd sandbox

git checkout feature
git rebase master
git checkout master
git merge --ff-only feature

popd
