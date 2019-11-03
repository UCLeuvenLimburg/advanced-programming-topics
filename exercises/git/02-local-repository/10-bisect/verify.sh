#/usr/bin/env bash

pushd sandbox > /dev/null

if [[ ! $(git tag | grep bugged) ]]; then
  echo fail: no tag bugged found
elif [[ $(git rev-parse master~15) != $(git rev-parse bugged) ]]; then
  echo fail: wrong commit is tagged as bugged
elif [[ $(git rev-parse master) != $(git rev-parse HEAD) ]]; then
  echo fail: HEAD should be reset to last commit
else
  echo ok
fi

popd > /dev/null
