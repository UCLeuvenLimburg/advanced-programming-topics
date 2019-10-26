#/usr/bin/env bash

pushd sandbox > /dev/null

if [[ $(git log --format=oneline | wc -l) != 3 ]]; then
  echo fail: git log should return three commits
elif [[ $(git log --format=oneline master | wc -l) != 4 ]]; then
  echo fail: master branch should count four commits
elif [[ $(git rev-parse HEAD) != $(git rev-parse master~1) ]]; then
  echo fail: HEAD not pointing to master~1
else
  echo ok
fi

popd > /dev/null
