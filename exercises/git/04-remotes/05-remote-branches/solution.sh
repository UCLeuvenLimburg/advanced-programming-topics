#/usr/bin/env bash

pushd sandbox

cd local

# Register remote repository
git remote add origin ../remote

# Fetch all information from remote repo
git fetch

# List remote branches
git branch -r

# Checkout each branch
git checkout master
git checkout branch-a
git checkout branch-b
git checkout branch-c

popd
