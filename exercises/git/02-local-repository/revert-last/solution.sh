#/usr/bin/env bash

pushd sandbox > /dev/null
git revert --no-edit HEAD
popd > /dev/null
