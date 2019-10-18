#/usr/bin/env bash

pushd sandbox > /dev/null

if [[ $(git log --format=%s) == "Correct message" ]]; then
  echo ok
else
  echo fail 
fi

popd > /dev/null
