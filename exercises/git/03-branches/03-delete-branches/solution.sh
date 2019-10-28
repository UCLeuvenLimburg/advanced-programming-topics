#/usr/bin/env bash

pushd sandbox
git branch | grep -v master | xargs -I{} git branch -d {}
popd
