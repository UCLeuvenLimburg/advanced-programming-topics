#/usr/bin/env bash

pushd sandbox > /dev/null

if [[ $(git log --format=%s) == "Initial commit" ]]; then
  echo ok
else
  echo fail 
fi

popd > /dev/null
