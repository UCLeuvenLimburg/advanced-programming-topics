#/usr/bin/env bash

pushd sandbox > /dev/null
git revert --no-edit HEAD~1
popd > /dev/null
