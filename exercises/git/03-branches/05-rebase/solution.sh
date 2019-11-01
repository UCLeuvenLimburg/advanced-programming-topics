#/usr/bin/env bash

pushd sandbox

git checkout feature
git rebase master
git checkout master

# --ff-only indicates that merging should only succeed if no merge commit is necessary
# This should be the case when rebasing
git merge --ff-only feature

popd
