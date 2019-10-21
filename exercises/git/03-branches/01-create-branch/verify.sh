#/usr/bin/env bash

pushd sandbox > /dev/null

if [[ $(git branch | wc -l) != 2 ]]; then
  echo fail: no branches expected
elif [[ ! $(git branch | grep master) ]]; then
  echo fail: missing master branch
elif [[ ! $(git branch | grep sidetrack) ]]; then
  echo fail: missing sidetrack branch
elif [[ $(git rev-parse sidetrack~1) != master ]]; then
  echo fail: sidetrack should be one ahead of master
else
  echo ok
fi

popd > /dev/null
