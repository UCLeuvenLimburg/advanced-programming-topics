#/usr/bin/env bash

pushd sandbox > /dev/null

if [[ $(git log --format=oneline | wc -l) == 3 ]]; then
  if [[ -f d.txt ]]; then
    if [[ $(git status --porcelain) == '?? d.txt' ]]; then
      echo ok
    else
      echo fail: d.txt should be removed from staging area
    fi
  else
    echo fail: d.txt should still be present in working area
  fi
else
  echo fail: history should only count three commits
fi

popd > /dev/null
