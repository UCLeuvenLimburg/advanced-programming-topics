#/usr/bin/env bash

pushd sandbox > /dev/null

if [[ $(git branch | wc -l) != 1 ]]; then
  echo fail: incorrect number of branches
elif [[ ! $(git branch | grep master) ]]; then
  echo fail: master should be only branch left
else
  echo ok
fi

popd > /dev/null
