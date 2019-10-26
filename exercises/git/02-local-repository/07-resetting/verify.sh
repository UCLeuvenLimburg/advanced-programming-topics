#/usr/bin/env bash

pushd sandbox > /dev/null

if [[ $(git log --format=oneline | wc -l) != 3 ]]; then
  echo fail: history should only count three commits
elif [[ ! -f d.txt ]]; then
  echo fail: d.txt should still be present in working area
elif [[ $(git status --porcelain) != '?? d.txt' ]]; then
  echo fail: d.txt should be removed from staging area
else
  echo ok
fi

popd > /dev/null
