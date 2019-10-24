#/usr/bin/env bash

pushd sandbox > /dev/null

if [[ $(git log --format=%s) != "Correct message" ]]; then
  echo fail 
else
  echo ok
fi

popd > /dev/null
