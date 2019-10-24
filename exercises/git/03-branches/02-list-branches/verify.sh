#/usr/bin/env bash

pushd sandbox > /dev/null

if [[ $(git rev-parse HEAD) != $(git rev-parse sycamore) ]]; then
  echo fail: not on correct branch
else
  echo ok
fi

popd > /dev/null
