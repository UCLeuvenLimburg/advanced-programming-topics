#/usr/bin/env bash

pushd sandbox > /dev/null

if [[ $(git log --format=oneline | wc -l) == 3 ]]; then
  if [[ $(git log --format=oneline master | wc -l) == 4 ]]; then
    if [[ $(git rev-parse HEAD) == $(git rev-parse master~1) ]]; then
      echo ok
    else
      echo fail: HEAD not pointing to master~1
    fi
  else
    echo fail: master branch should count four commits
  fi
else
  echo fail: git log should return three commits
fi

popd > /dev/null
