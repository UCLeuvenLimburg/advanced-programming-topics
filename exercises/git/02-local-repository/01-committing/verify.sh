#/usr/bin/env bash

pushd sandbox > /dev/null

if [[ $(git log --format=%s) != "Initial commit" ]]; then
  echo fail 
else
  echo ok
fi

popd > /dev/null
