#/usr/bin/env bash

pushd sandbox > /dev/null

git checkout master

if [[ $(git log --format=oneline) != 3 ]]; then
  echo fail: log should contain three commits
elif [[ ! -f file.txt ]]; then
  echo fail: file.txt should be present
elif [[ ! -f file2.txt ]]; then
  echo fail: file2.txt should be present
elif [[ ! -f file3.txt ]]; then
  echo fail: file3.txt should be present
else
  echo ok
fi

popd > /dev/null
