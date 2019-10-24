#/usr/bin/env bash

pushd sandbox

BRANCH=$(git branch | sort | tail -n 1)
echo $BRANCH

popd
