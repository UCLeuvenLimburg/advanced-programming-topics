#/usr/bin/env bash

pushd sandbox > /dev/null
git log -n 1 c.txt 
popd > /dev/null
